using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RetornandoTitulo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Variável global 
            IWebElement CampoPesquisar = null;
            IWebElement ProximaPagina = null;
            int TotalTitulo = 9;

            // Abrindo e buscando a pagina do Google
            IWebDriver Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("https://www.google.com/");

            //Maximizar o browser
            Driver.Manage().Window.Maximize();

            // Selecionando a barra de pesquisa
            try
            {
                CampoPesquisar = Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[1]/div/div[2]/input"));
                CampoPesquisar.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao selecionar barra de pesquisa {e}");
            }

            // Escrevendo a pesquisa desejada / Clicando na pagina 
            try
            {
                CampoPesquisar.SendKeys("Google");
                CampoPesquisar = Driver.FindElement(By.XPath("/html/body/div[1]/div[3]"));
                CampoPesquisar.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao escrever a pesquisa desejada / clicar na página {e}");
            }

            // Clicando no botão de pesquisar
            try
            {
                IWebElement BotaoPesquisar = Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/form/div[1]/div[1]/div[3]/center/input[1]"));
                BotaoPesquisar.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao clicar no botão pesquisar {e}");
            }
            // Retornando as 10 primeiras páginas
            IList<IWebElement> Lista = new List<IWebElement>();
            Lista = Driver.FindElements(By.XPath("//div//div//div//a//h3"));
            try
            {
                if (Lista.Count == TotalTitulo)
                {
                    Console.WriteLine();
                    foreach (var item in Lista)
                    {
                        Console.WriteLine($" ---> {item.Text}");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine();
                    foreach (var item in Lista)
                    {
                        Console.WriteLine($" ---> {item.Text}");
                    }
                    ProximaPagina = Driver.FindElement(By.XPath("/html/body/div[7]/div/div[8]/div[1]/div/div[6]/span[1]/table/tbody/tr/td[3]/a"));
                    ProximaPagina.Click();
                    Thread.Sleep(3500);
                    if (ProximaPagina != null)
                    {
                        Lista = Driver.FindElements(By.XPath("//div//div//div//a//h3"));
                        foreach (var item in Lista)
                        {
                            Console.WriteLine($" ---> {item.Text}");
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro ao retornar as páginas {e}");
            }
        }
    }
}
