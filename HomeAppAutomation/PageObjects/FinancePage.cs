using HomeAppAutomations;
using HomeAppAutomations.PageObjects;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NSelene;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using System.Threading.Tasks;

namespace HomeAppAutomation.PageObjects
{
    class FinancePage : BasePage
    {
        public FinancePage(AppiumDriver<AppiumWebElement> driver) : base(driver)
        { }
        public SeleneElement FinanceTab => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/menuItemFinance"), MobileBy.AccessibilityId("Finance"));
        public SeleneElement FinanceTitle => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Finance']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Finance\"]"));
        public SeleneElement ServiceName => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvServiceName"), MobileBy.AccessibilityId("TEST_AUTOMATION"));
        public SeleneElement AccountService => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Account Summary ']"), MobileBy.AccessibilityId("Account Summary"));
        public SeleneElement OwingBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/clOwing"), MobileBy.XPath("(//XCUIElementTypeButton[@name=\"Transactions\"])[2]"));
        public SeleneElement PayNow => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnPayNow"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Pay Now $']"));
        public SeleneElement EnterAmount => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tiAmountEntered"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='$']"));
        public SeleneElement SendBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/sendBtn"), MobileBy.AccessibilityId("send icon"));
        public  SeleneElement PaymentConfirmationMsg=> GetPlatformSpecificElement(MobileBy.Id("android:id/message"), MobileBy.AccessibilityId("Your payment may take up to 30 minutes to show up in your transaction history."));
        public SeleneElement AlreadyPaymentDoneMsg => GetPlatformSpecificElement(MobileBy.Id("android:id/message"), MobileBy.AccessibilityId("You have to wait up to 30 minutes to complete another payment."));
        public SeleneElement Name=> GetPlatformSpecificElement(MobileBy.Id("Name"), MobileBy.XPath("//XCUIElementTypeOther[@name=\"Payment Details\"]/XCUIElementTypeTextField[1]"));
        public SeleneElement CardNumber => GetPlatformSpecificElement(MobileBy.Id("BSB"), MobileBy.XPath("//XCUIElementTypeOther[@name='Payment Details']/XCUIElementTypeTextField[2]"));
        public SeleneElement ExpiryMM=> GetPlatformSpecificElement(MobileBy.Id("Expiry MM"), MobileBy.XPath("(//XCUIElementTypeOther[@name='Expiry date'])[2]"));
        public SeleneElement ExpiryYY => GetPlatformSpecificElement(MobileBy.Id("Expiry YY"), MobileBy.IosClassChain("**/XCUIElementTypeOther[`value == 'YYYY'`]"));
        public SeleneElement CVV => GetPlatformSpecificElement(MobileBy.Id("CVV"), MobileBy.XPath("//XCUIElementTypeOther[@name=\"Payment Details\"]/XCUIElementTypeTextField[3]"));
        public SeleneElement NextBtn => GetPlatformSpecificElement(MobileBy.Id("Next"), MobileBy.AccessibilityId("Next >"));
        public SeleneElement ConfirmBtn => GetPlatformSpecificElement(MobileBy.Id("Confirm"), MobileBy.AccessibilityId("Confirm"));
        public SeleneElement ContinueBtn => GetPlatformSpecificElement(MobileBy.Id("Continue"), MobileBy.XPath("//XCUIElementTypeStaticText[@name=\"Continue\"]"));
        public SeleneElement SetupDirectDebit => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Setup Direct Debit ']"), MobileBy.AccessibilityId("Setup Direct Debit"));
        public SeleneElement ShowStatement => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Show Statement ']"), MobileBy.AccessibilityId("Show Statement"));
        public SeleneElement StatementTitle => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvTitle"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Statement']"));
        public SeleneElement ViewAccountSummaryBtn => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/btnFooterSend"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='View Account Summary']"));
        public SeleneElement AmountDue => GetPlatformSpecificElement(MobileBy.Id("com.xplor.home.staging:id/tvItemStatementLabel"), MobileBy.XPath("//XCUIElementTypeOther[@name='AMOUNT DUE']"));
        public SeleneElement Value2 => GetElementByXPath("//XCUIElementTypeKey[@name='2']");
        public SeleneElement Value5 => GetElementByXPath("//XCUIElementTypeKey[@name='5']");
        public SeleneElement ChangeDirectDebit => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Change Direct Debit ']"), MobileBy.AccessibilityId("Change Direct Debit"));
        public SeleneElement ChangeBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.TextView[@text='Change']"), MobileBy.XPath("//XCUIElementTypeStaticText[@name='Change']"));
        public SeleneElement HolderName => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.EditText[@resource-id='CcHolderName']"), MobileBy.XPath("//XCUIElementTypeOther[@name=\"Debitsuccess\"]/XCUIElementTypeTextField[1]"));
        public SeleneElement CardNo => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.EditText[@resource-id='CreditCardNumber']"), MobileBy.IosClassChain("**/XCUIElementTypeTextField[`label == \"Card number\"`]"));
        public SeleneElement ExpiryMonth => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View[@resource-id='ExpiryMonth']"), MobileBy.XPath("(//XCUIElementTypeOther[@name=\"Valid To\"])[2]"));
        public SeleneElement ExpiryYear => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View[@resource-id='ExpiryYear']"), MobileBy.XPath("//XCUIElementTypeOther[@name=\"Debitsuccess\"]/XCUIElementTypeOther[11]"));
        public SeleneElement AddDetailBtn => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.Button[@resource-id='submit--update__cc']"), MobileBy.AccessibilityId("Add details")); 
        public SeleneElement SelectExpiryMonth=> GetPlatformSpecificElement(MobileBy.XPath("//android.widget.CheckedTextView[@text='05']"), MobileBy.AccessibilityId("05")); ////XCUIElementTypeButton[@name="05"]
        public SeleneElement SelectExpiryYear => GetPlatformSpecificElement(MobileBy.XPath("//android.widget.CheckedTextView[@text='2028']"), MobileBy.AccessibilityId("2028")); ////XCUIElementTypeButton[@name="2028"]
        public SeleneElement Continue=>GetPlatformSpecificElement(MobileBy.XPath("//android.view.View[@resource-id='redirect-link']"), MobileBy.AccessibilityId("Continue"));
        public SeleneElement CreditCardPage => GetPlatformSpecificElement(MobileBy.XPath("//android.view.View[@text='Payment details updated']"), MobileBy.AccessibilityId("Payment details updated"));
       
        public void ClickOnContinue()
        {
            this.ClickElement(Continue);
        }
        public void ValidateCreditCardPageIsDisplayed()
        {
            this.WaitForElement(10000);
            bool IsCreditCardPageDisplayed = IsElementDisplayed(CreditCardPage);
            Assert.IsTrue(IsCreditCardPageDisplayed, "Credit Card page is not displayed");          
        }
        public void ClickOnChangeDirectDebitBtn()
        {
            this.ClickElement(ChangeDirectDebit);
        }
        public void ClickOnChangeBtn()
        {
            this.ClickElement(ChangeBtn);
        }
        public void ClickOnAddDetailBtn()
        {
            this.ClickElement(AddDetailBtn);
        }
        public void EnterHolderName(string holderName)
        {
            this.EnterText(HolderName, holderName);
        }
        public void EnterCardNo(string cardNo)
        {
            this.EnterText(CardNo, cardNo);
        }
        public void EnterExpiryMonth()
        {
            this.ClickElement(ExpiryMonth);
            this.ClickElement(SelectExpiryMonth);
        }
        public void EnterExpiryYear()
        {
            this.ClickElement(ExpiryYear);
            this.ClickElement(SelectExpiryYear);
        }

        public void ChangeDirectDebitDetails()
        {
            this.ClickOnChangeDirectDebitBtn();
            this.WaitForElementToBeClickable();
            this.ClickOnChangeBtn();
            this.WaitForElement(15000);
            this.EnterHolderName("Auto Test");
            this.EnterCardNo("4111111111111111");
            this.EnterExpiryMonth();
            this.EnterExpiryYear();
            this.ClickOnAddDetailBtn();
            this.WaitForElementToBeClickable();
           // this.ClickOnContinue();
        }


        public void TypeName(string name)
        {
            this.EnterText(Name, name);
        }
        public void TypeCardNumber(string cardNumber)
        {
            this.EnterText(CardNumber, cardNumber);
        }
        public void TypeExpiryMM(string expiryMM)
        {
            this.EnterText(ExpiryMM, expiryMM);
        }
        
        public void TypeExpiryYY(string expiryYY)
        {
            this.EnterText(ExpiryYY, expiryYY);
        }
        public void TypeCVV(string cvv)
        {
            this.EnterText(CVV, cvv);
        }
        public void ClickOnNextBtn()
        {
            this.ClickElement(NextBtn);
        }
        public void ClickOnConfirmBtn()
        {
            this.ClickElement(ConfirmBtn);
        }
        public void ClickOnContinueBtn()
        {
            this.ClickElement(ContinueBtn);
        }

        public void FillCreditCardDetails()
        {
            Task.Delay(10000).Wait();
            if(IsElementDisplayed(Name))
            {
                this.TypeName("Test Automation");
                this.TypeCardNumber("4111111111111111");
                this.TypeExpiryMM("12");
                this.TypeExpiryMM("2028");
                this.TypeCVV("123");
                this.ClickOnNextBtn();
                this.ClickOnConfirmBtn();
                this.ClickOnContinueBtn();
            }            
        }

        public void EnterPaymentInformation()
        {
            this.WaitForElementToBeClickable();
            this.ClickOnPayNowBtn();
            this.WaitForElementToBeClickable();
            if(IsElementDisplayed(EnterAmount))
            {
                this.EnterAmountToPay("100");
                this.ClickOnSendBtn();
                if (MobileDriver.IsIOS)
                {
                    this.FillCreditCardDetails();
                }                
            }                               
        }
        public void ClickOnValue2()
        {     
            this.ClickElement(Value2);
        }


        public void ClickOnValue5()
        {
            this.ClickElement(Value5);
        }
        public void ValidateAmountDueIsDisplayed()
        {
            bool IsAmountDueDisplayed = IsElementDisplayed(AmountDue);
            Assert.IsTrue(IsAmountDueDisplayed, "Amount Due is not displayed");
        }
        public void ClickOnShowStatementBtn()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(ShowStatement);
        }
        public void ValidateStatementTitleIsDisplayed()
        {
            this.WaitForElementToBeClickable();
            string actualStatementTitle = GetElementText(StatementTitle);
            string expectedStatementTitle = "Statement";
            Assert.AreEqual(expectedStatementTitle, actualStatementTitle, "Statement title is not displayed");
        }
        public void ValidateViewAccountSummaryBtnIsDisplayed()
        {
            bool IsViewAccountSummaryBtnDisplayed = IsElementDisplayed(ViewAccountSummaryBtn);
            Assert.IsTrue(IsViewAccountSummaryBtnDisplayed, "View Account Summary button is not displayed");
        }
        public void ValidatePaymentConfirmationMsgIsDisplayed()
        {
            this.WaitForElementToBeClickable();
            if(MobileDriver.IsAndroid)
            {
                if (IsElementDisplayed(AlreadyPaymentDoneMsg))
                {
                    string actualAlreadyPaymentDoneMsg = GetElementText(AlreadyPaymentDoneMsg);
                    string expectedAlreadyPaymentDoneMsg = "You have to wait up to 30 minutes to complete another payment.";
                    Assert.AreEqual(expectedAlreadyPaymentDoneMsg, actualAlreadyPaymentDoneMsg, "Already payment done message is not displayed");
                }
                else if (IsElementDisplayed(PaymentConfirmationMsg))
                {
                    string actualPaymentConfirmationMsg = GetElementText(PaymentConfirmationMsg);
                    string expectedPaymentConfirmationMsg = "Your payment may take up to 30 minutes to show up in your transaction history.";
                    Assert.AreEqual(expectedPaymentConfirmationMsg, actualPaymentConfirmationMsg, "Payment confirmation message is not displayed");
                }
                else
                {
                    Assert.Pass("Payment details form is opened and can not proceed further as WebView is disabled for now");
                }
            }
            else
            {
                if (IsElementDisplayed(AlreadyPaymentDoneMsg))
                {
                    string actualAlreadyPaymentDoneMsg = GetElementText(AlreadyPaymentDoneMsg);
                    string expectedAlreadyPaymentDoneMsg = "You have to wait up to 30 minutes to complete another payment.";
                    Assert.AreEqual(expectedAlreadyPaymentDoneMsg, actualAlreadyPaymentDoneMsg, "Already payment done message is not displayed");
                }
                else
                {
                    string actualPaymentConfirmationMsg = GetElementText(PaymentConfirmationMsg);
                    string expectedPaymentConfirmationMsg = "Your payment may take up to 30 minutes to show up in your transaction history.";
                    Assert.AreEqual(expectedPaymentConfirmationMsg, actualPaymentConfirmationMsg, "Payment confirmation message is not displayed");
                }
            }               
        }
        public void ClickOnSendBtn()
        {
            this.ClickElement(SendBtn);
        }
        public void EnterAmountToPay(string amount)
        {
            this.WaitForElementToBeClickable();
            this.EnterText(EnterAmount, amount);            
        }
        public void ClickOnPayNowBtn()
        {
            Task.Delay(3000).Wait();
            this.ClickElement(PayNow);
        }

        public void ClickOnFinanceTab()
        {
            this.ClickElement(FinanceTab);
        }
        public void ValidateFinanceTitleIsDisplayed()
        {
            string actualFinanceTitle = GetElementText(FinanceTitle);
            string expectedFinanceTitle = "Finance";
            Assert.AreEqual(expectedFinanceTitle, actualFinanceTitle, "Finance title is not displayed");
        }
        public void ClickOnServiceName()
        {
            this.WaitForElementToBeClickable();
            this.ClickElement(ServiceName);
        }
        public void ClickOnAccountService()
        {
            this.ClickElement(AccountService);
        }
        public void ValidateOwingAmountIsDisplayed()
        {
            Task.Delay(3000).Wait();
            bool IsOwingBtnDisplayed = IsElementDisplayed(OwingBtn);
            Assert.IsTrue(IsOwingBtnDisplayed, "Owing amount is not displayed");
        }

    }
}
