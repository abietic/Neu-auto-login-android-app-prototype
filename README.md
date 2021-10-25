# Neu-auto-login-android-app-prototype
An Android app to login neu network automatically

在visual studio 2019中使用xamarin和Android支持编写的东北大学校园网一键登录程序

需要自行在代码中添加自己统一身份认证用的学号和密码（明文，注意个人信息安全），并进行编译安装到手机，在手机连入校园网wifi后，打开app直到页面显示网络已连接的网页

程序执行流程：设置在网页加载完毕后插入自动登录用的js执行代码，打开使用统一身份认证进行网络登录的url，当url对应网页加载完毕，js代码执行，校园网登录完毕

注：需要在manifest xml中申明app使用网络