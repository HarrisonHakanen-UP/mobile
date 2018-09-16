using System.Threading.Tasks;
using SebraeCore.Shared.Api;
using SebraeCore.Shared.Models;
using SebraeCore.Shared.SebraeQ.Models;
using SebraeCore.Shared.SebraeQ.Models.Convert;
using System;


namespace SebraeCore.Shared.SebraeQ.BussinessObjects
{
    public class Login
    {
		//Esse  esta estranhdo como publico 
		// tem que ser emcapsulado usuario esta com problema tem que trocar isso para a classe user e nao usuario
        public static Usuario UsuarioValido { get; private set; }

        private NanLoginApi _nanApiLogin;
        private Usuario _usuario;
        
        
        public Login()
        {
            //Init("dtsouza", "dts12345");
			Init("", "");
        }

        public Login(string user, string senha)
        {
            _usuario = null;
            Init(user, senha);
        }

        public Login(UsuarioDetalhes objUser, string token)
        {
            _nanApiLogin = new NanLoginApi();
            UsuarioValido = new Usuario
            {
                accessToken = token,
                usuarioDetalhes = objUser
            };
        }

        public string GetAccessToken() {

            return UsuarioValido.accessToken;
        }

        public async Task<SuccessfulAnswer> DoValidateToken()
        {
            try
            {
                var result = await _nanApiLogin.LoginTokenGet(UsuarioValido.accessToken);

                if (result != null)
                    UsuarioValido = result;

                return new SuccessfulAnswer() { Success = true };
            }
            catch (Exception ex)
            {
                return new SuccessfulAnswer() { TitleMessage = "Erro!", Message = ex.Message, Success = false };
            }
        }
        
        public async Task<SuccessfulAnswer> DoLogin(string user, string senha)
        {
            try
            {

                Init(user, senha);

                UsuarioValido = new Usuario();
                UsuarioValido = await _nanApiLogin.LoginUsuarioGet(_usuario);

                UsuarioValido.login = user;
                UsuarioValido.senha = senha;

                return new SuccessfulAnswer() { Success = true };
            }
            catch (Exception ex)
            {
                if(ex.Message == "Object reference not set to an instance of an object.")
                    return new SuccessfulAnswer() { TitleMessage = "Erro!", Message = "Erro ao efetuar o login, verifique sua internet!", Success = false };
                else
                    return new SuccessfulAnswer() { TitleMessage = "Erro!",  Message = ex.Message, Success = false };
            }
        }

        public async Task<SuccessfulAnswer> DoLogout()
        {
            try
            {
                await _nanApiLogin.LogoutGet(UsuarioValido.accessToken);
                return new SuccessfulAnswer() { Success = true };
            }
            catch (Exception ex)
            {
                return new SuccessfulAnswer() { TitleMessage = "Erro!", Message = ex.Message, Success = false };
            }
        }

        public async Task<SuccessfulAnswer> DoRequestAcess(string user, string strEmail, string strDescription)
        {
            try
            {
                _usuario = new Usuario
                {
                    login = user,
                    usuarioDetalhes = new UsuarioDetalhes() { email = strEmail }
                };

                return new ParseSuccessfulAnswer().Parse(await _nanApiLogin.LoginSolicitarAcessoGet(_usuario, strDescription)); 
            }
            catch (Exception ex)
            {
                return new SuccessfulAnswer() { TitleMessage = "Erro!", Message = ex.Message, Success = false };
            }
        }

        public async Task<SuccessfulAnswer> DoPasswordRecovery(string user)
        {
            try
            {
                return new ParseSuccessfulAnswer().Parse(await _nanApiLogin.LoginRecuperarSenhaGet(user));
            }
            catch (Exception ex)
            {
                return new SuccessfulAnswer() { TitleMessage = "Erro!", Message = ex.Message, Success = false };
            }
        }

        public async Task<SuccessfulAnswer> DoPasswordChange(string strSenhaAtual, string strNovaSenha, string strConfirmarNovaSenha)
        {
            try
            {
                return new ParseSuccessfulAnswer().Parse(await _nanApiLogin.LoginAtualizarSenhatGet(UsuarioValido.accessToken, strSenhaAtual, strNovaSenha, strConfirmarNovaSenha)); 
            }
            catch (Exception ex)
            {
                return new SuccessfulAnswer() { TitleMessage = "Erro!", Message = ex.Message, Success = false };
            }
        }

        public SuccessfulAnswer ValidationFields(string Cpf)
        {
            if (String.IsNullOrEmpty(Cpf))
                return new SuccessfulAnswer { Success = false, Message = "Digite seu login!", TitleMessage = "Erro!" };

            return new SuccessfulAnswer { Success = true };
        }

        public SuccessfulAnswer ValidationFields(string Cpf, string Email, string Motivation)
        {
            if (String.IsNullOrEmpty(Email))
                return new SuccessfulAnswer { Success = false, Message = "Digite seu e-mail!", TitleMessage = "Erro!" };

            if (String.IsNullOrEmpty(Cpf))
                return new SuccessfulAnswer { Success = false, Message = "Digite seu login!", TitleMessage = "Erro!" };

            if (String.IsNullOrEmpty(Motivation))
                return new SuccessfulAnswer { Success = false, Message = "Digite seu motivo!", TitleMessage = "Erro!" };

            return new SuccessfulAnswer { Success = true };
        }

        protected void Init(string login, string senha)
        {
            _nanApiLogin = new NanLoginApi();
            _usuario = new Usuario
            {
                login = login,
                senha = senha,
                detalheMobile = "detalhe do dispositivo"
            };
        }
    }
}
