# How to setup and run Selenium tests
1.	Install Visual Studio: https://www.browserstack.com/guide/setup-selenium-on-visual-studio
2.	Open project by clicking on SeleniumFramework.sln
3.	Install all the following packages (How to add packages: https://www.browserstack.com/guide/setup-selenium-on-visual-studio  > Add Selenium Libraries and Drivers )
 ```
  <package id="Crc32C.NET" version="1.0.5.0" targetFramework="net461" />
  <package id="DnsClient" version="1.2.0" targetFramework="net461" />
  <package id="ExtentReports" version="2.41.0" targetFramework="net461" />
  <package id="Microsoft.AspNet.Razor" version="3.0.0" targetFramework="net472" />
  <package id="MongoDB.Bson" version="2.10.2" targetFramework="net461" />
  <package id="MongoDB.Driver" version="2.10.2" targetFramework="net461" />
  <package id="MongoDB.Driver.Core" version="2.10.2" targetFramework="net461" />
  <package id="MongoDB.Libmongocrypt" version="1.0.0" targetFramework="net461" />
  <package id="MSTest.TestAdapter" version="1.3.2" targetFramework="net472" />
  <package id="MSTest.TestFramework" version="1.3.2" targetFramework="net472" />
  <package id="Newtonsoft.Json" version="12.0.1" targetFramework="net472" />
  <package id="NUnit" version="3.12.0" targetFramework="net461" />
  <package id="NUnit3TestAdapter" version="3.16.1" targetFramework="net461" developmentDependency="true" />
  <package id="RazorEngine" version="3.10.0" targetFramework="net472" />
  <package id="Selenium.Firefox.WebDriver" version="0.26.0" targetFramework="net472" />
  <package id="Selenium.InternetExplorer.WebDriver" version="3.150.1" targetFramework="net472" />
  <package id="Selenium.WebDriver" version="3.141.0" targetFramework="net461" />
  <package id="Selenium.WebDriver.ChromeDriver" version="97.0.4692.7100" targetFramework="net461" />
  <package id="SharpCompress" version="0.23.0" targetFramework="net461" />
  <package id="Snappy.NET" version="1.1.1.8" targetFramework="net461" />
  <package id="System.Buffers" version="4.4.0" targetFramework="net461" />
  <package id="System.Runtime.InteropServices.RuntimeInformation" version="4.3.0" targetFramework="net461" />
```
4. How to run the tests
```
Go to View > Test Explorer 
Select your test > Right click > Run  
OR Select Run All Test In View
```
5. How to access the generated Selenium report
```
Go to ..\SeleniumFramework\Test_Execution_Reports\QASeleniumTasks_6-19-2022  (example today is 19/06/2022)(test folder name will contain test datetime)
Open htmlReport.html
```

# Where to view Overall Evaluation Report and Manual test cases
````commandline
..\SeleniumFramework\Report
- BugReport.pdf: bug report in details
- OverallEvaluationTestReport.pptx: the overal test report for this application
- WebQAAssignment.xlsx: a series of manual test cases
````