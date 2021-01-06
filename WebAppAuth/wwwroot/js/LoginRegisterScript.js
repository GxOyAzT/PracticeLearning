function ClickLoginContainer() {
    var loginContainerId = document.getElementById("LoginContainerId");
    var registerContainerId = document.getElementById("RegisterContainerId");
    var loginLabel = document.getElementById("LoginLabel");
    var registerLabel = document.getElementById("RegisterLabel");
    var logInFormId = document.getElementById("LogInFormId");
    var registerFormId = document.getElementById("RegisterFormId");


    loginContainerId.style.zIndex = "2";
    loginContainerId.style.right = "0px";
    loginContainerId.style.height = "100%";
    loginContainerId.style.width = "330px";
    loginLabel.style.top = "20%";
    logInFormId.style.top = "40%";


    registerContainerId.style.zIndex = "1";
    registerContainerId.style.right = "calc(100% - 270px)";
    registerContainerId.style.height = "80%";
    registerContainerId.style.width = "270px";
    registerLabel.style.top = "50%";
    registerFormId.style.top = "100%";

    if (window.innerWidth < 500) {
        var buttonChangeToLogIn = document.getElementById("ButtonChangeToLogIn");
        var buttonChangeToRegister = document.getElementById("ButtonChangeToRegister");

        buttonChangeToLogIn.style.display = "block";
        buttonChangeToRegister.style.display = "none";
    }
}

function ClickRegisterContainer() {
    var registerContainerId = document.getElementById("RegisterContainerId");
    var loginContainerId = document.getElementById("LoginContainerId");
    var loginLabel = document.getElementById("LoginLabel");
    var registerLabel = document.getElementById("RegisterLabel");
    var logInFormId = document.getElementById("LogInFormId");
    var registerFormId = document.getElementById("RegisterFormId");

    loginContainerId.style.zIndex = "1";
    loginContainerId.style.right = "calc(100% - 270px)";
    loginContainerId.style.height = "80%";
    loginContainerId.style.width = "270px";
    loginLabel.style.top = "50%";
    logInFormId.style.top = "100%";

    registerContainerId.style.zIndex = "2";
    registerContainerId.style.right = "0px";
    registerContainerId.style.height = "100%";
    registerContainerId.style.width = "330px";
    registerLabel.style.top = "20%";
    registerFormId.style.top = "40%";


    if (window.innerWidth < 500) {
        var buttonChangeToLogIn = document.getElementById("ButtonChangeToLogIn");
        var buttonChangeToRegister = document.getElementById("ButtonChangeToRegister");

        buttonChangeToLogIn.style.display = "none";
        buttonChangeToRegister.style.display = "block";
    }
}

function ClickLoginButton() {
    ClickLoginContainer();
}

function ClickRegisterButton() {
    ClickRegisterContainer();
}

function HideLoginErrorMessagesPanel() {
    document.getElementById("LoginErrorMessagesPanelId").style.display = "none";
    document.getElementById("Shader").style.display = "none";
}