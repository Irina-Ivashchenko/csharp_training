﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
            : base(manager)
        {
        }
  
        public ContactHelper Create(ContactData contact)
        {
           manager.Navigator.OpenHomePage();

           InitContactCreation();
           FillContactForm(contact);
           SubmitContactCreation();
           manager.Navigator.ReturnToHomePage();
           return this;
        }

        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(v);
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.OpenHomePage();

            SelectContact(v);
            RemoveContact();
            driver.SwitchTo().Alert().Accept();
            manager.Navigator.OpenHomePage();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//tr[@name=\"entry\"][" + (index+1) + "]//input[@type=\"checkbox\"]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("//tr[@name=\"entry\"][" + (index+1) + "]//img[@title=\"Edit\"]")).Click();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            /* Type(By.Name("nickname"), contact.Nickname);
             Type(By.Name("notes"), contact.Notes); */
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public bool IsContactCreate()
        {
            return IsElementPresent(By.Name("entry"));
        }

        public List<ContactData> GetContactList()
        {
               List<ContactData> contacts = new List<ContactData>();
               manager.Navigator.OpenHomePage();
               ICollection<IWebElement> elements = driver.FindElements(By.XPath("//tr[@name='entry']"));
               int i = 1;

            foreach (IWebElement element in elements)
            {
                IWebElement firstname = driver.FindElement(By.XPath("//tbody/tr[" + (i + 1) + "]/td[3]"));
                IWebElement lastname = driver.FindElement(By.XPath("//tbody/tr[" + (i + 1) + "]/td[2]"));
                contacts.Add(new ContactData(firstname.Text, lastname.Text));
                i++;
            }
    return contacts;
        }
    }
}
