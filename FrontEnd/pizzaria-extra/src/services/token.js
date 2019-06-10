export const Token = () => {
  try {
      const base64Url = localStorage.getItem("Usuario-Pizzaria").split(".")[1];
      const base64 = base64Url.replace(/-/g, "+"); base64Url.replace(/_/g ,"/");
      const token = JSON.parse(window.atob(base64));
      if (ValidacaoToken(token) !== false) {
          return token;
      } else {
          return null;
      }
  } catch (error) {
      console.log(error);
      return null;
  }
}

const ValidacaoToken = (token) => {
  
  if (token !== null) {
      if (Date.now() < token.exp * 1000) {
          return true;
      } else {
          return false;
      }
  }
}