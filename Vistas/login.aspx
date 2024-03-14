<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Vistas_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 <!--Stylesheet-->
    <style media="screen">
      *,
*:before,
*:after{
    padding: 0;
    margin: 0;
    box-sizing: border-box;
}
body{
    background-color: #080710;
}
.background{
    width: 430px;
    height: 520px;
    position: absolute;
    transform: translate(-50%,-50%);
    left: 50%;
    top: 50%;
}
.background .shape{
    height: 200px;
    width: 200px;
    position: absolute;
    border-radius: 50%;
}
.shape:first-child{
    background: linear-gradient(
        #1845ad,
        #23a2f6
    );
    left: -80px;
    top: -80px;
}
.shape:last-child{
    background: linear-gradient(
        to right,
        #ff512f,
        #f09819
    );
    right: -30px;
    bottom: -80px;
}
.form{
    height: 520px;
    width: 400px;
    background-color: rgba(255,255,255,0.13);
    position: absolute;
    transform: translate(-50%,-50%);
    top: 50%;
    left: 50%;
    border-radius: 10px;
    backdrop-filter: blur(10px);
    border: 2px solid rgba(255,255,255,0.1);
    box-shadow: 0 0 40px rgba(8,7,16,0.6);
    padding: 50px 35px;
}
.form *{
    font-family: 'Poppins',sans-serif;
    color: #ffffff;
    letter-spacing: 0.5px;
    outline: none;
    border: none;
}
.form h3{
    font-size: 32px;
    font-weight: 500;
    line-height: 42px;
    text-align: center;
}

label{
    display: block;
    margin-top: 30px;
    font-size: 16px;
    font-weight: 500;
}
input{
    display: block;
    height: 50px;
    width: 100%;
    background-color: rgba(255,255,255,0.07);
    border-radius: 3px;
    padding: 0 10px;
    margin-top: 8px;
    font-size: 14px;
    font-weight: 300;
}
::placeholder{
    color: #e5e5e5;
}
button{
    margin-top: 50px;
    width: 100%;
    background-color: #ffffff;
    color: #080710;
    padding: 15px 0;
    font-size: 18px;
    font-weight: 600;
    border-radius: 5px;
    cursor: pointer;
}
.social{
  margin-top: 30px;
  display: flex;
}
.social div{
  background: red;
  width: 150px;
  border-radius: 3px;
  padding: 5px 10px 10px 5px;
  background-color: rgba(255,255,255,0.27);
  color: #eaf0fb;
  text-align: center;
}
.social div:hover{
  background-color: rgba(255,255,255,0.47);
}
.social .fb{
  margin-left: 25px;
}
.social i{
  margin-right: 4px;
}

.input-container {
            position: relative;
            margin-top: 30px;
        }
        .input-container label {
            position: absolute;
            left: 10px;
            top: -10px;
            color: #ffffff;
            font-size: 14px;
            pointer-events: none;
            transition: 0.3s;
        }
        .input-container input:focus + label,
        .input-container input:not(:placeholder-shown) + label {
            top: -25px;
            font-size: 12px;
            color: #23a2f6; /* Color de resaltado */
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
      <div>
           <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div>
    <div class="form">
        <h3>Login Here</h3>
            <div class="input-container">
                          
                <asp:TextBox ID="txtuser" runat="server" placeholder="" ></asp:TextBox>
                            <label for="username">Usuario</label>
                        </div>

                        <!-- Contenedor para el input de Password -->
                        <div class="input-container">
                  
                            <asp:TextBox ID="txtpassword" placeholder ="" runat="server"></asp:TextBox>
                            <label for="password">password</label>
                        </div>


        <asp:Image runat="server" ID="imgCaptcha" style="margin-top:20px;margin-right:100px;" />
        <asp:TextBox ID="txtCaptcha" runat="server" Visible="true"></asp:TextBox>

        <asp:Label ID="lblRespuesta" runat="server" Text=""></asp:Label>

        <asp:Button ID="btncaptcha" runat="server" Text="Validar Captcha"  OnClick="btncaptcha_Click" Visible ="true"/>

        <asp:LinkButton ID="lbtnacceso" runat="server" CssClass="go" style="color:black; margin-top:20px;" OnClick="lbtnacceso_Click" Visible="false">Acceso</asp:LinkButton>
     
        </div>
   </div>
   </form>
</body>
</html>
