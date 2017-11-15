using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Управление общими сведениями о сборке осуществляется с помощью 
// набора атрибутов. Измените значения этих атрибутов для изменения сведений,
// связанных с этой сборкой.
[assembly: AssemblyTitle("Reminder.WebUI")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Reminder.WebUI")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Установка значения false в параметре ComVisible делает типы в этой сборке невидимыми 
// для компонентов COM. Если требуется обратиться к типу в этой сборке через 
// COM, задайте атрибуту ComVisible значение true для требуемого типа.
[assembly: ComVisible(false)]

// Следующий GUID служит для идентификации библиотеки типов typelib, если этот проект видим для COM
[assembly: Guid("022b5458-f549-4f0e-a59b-7909a3218686")]

// Сведения о версии сборки состоят из указанных ниже четырех значений:
//
//      основной номер версии;
//      дополнительный номер версии;
//      номер сборки;
//      редакция.
//
// Можно задать все значения или принять номер сборки и номер редакции по умолчанию, 
// используя "*", как показано ниже:
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
//run the configurator
[assembly: log4net.Config.XmlConfigurator( ConfigFile = "LoggerWeb.config", Watch = true)]
