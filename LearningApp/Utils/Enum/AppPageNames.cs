using LearningApp.Assets.Lang;
using LearningApp.Utils.LocalizationManager;

namespace LearningApp.Utils.Enum;

public enum AppPageNames
{
    [LocalizedDescription("LogIn", typeof(Resources))]
    LogIn,

    [LocalizedDescription("SignUp", typeof(Resources))]
    SignUp,
    MainApp,

    [LocalizedDescription("Home", typeof(Resources))]
    Home,

    [LocalizedDescription("Courses", typeof(Resources))]
    Courses,

    [LocalizedDescription("Dictionaries", typeof(Resources))]
    Dictionaries,

    [LocalizedDescription("Settings", typeof(Resources))]
    Settings,

    [LocalizedDescription("Profile", typeof(Resources))]
    Profile,


    [LocalizedDescription("Words", typeof(Resources))]
    Words,

    [LocalizedDescription("Statistics", typeof(Resources))]
    Statistics
}