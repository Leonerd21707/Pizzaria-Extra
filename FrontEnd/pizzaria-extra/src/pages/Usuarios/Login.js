import React, { Component } from "react";
import Axios from "axios";

class Login extends Component {
  constructor(props) {
    super(props);
    this.state = {
      nome: "",
      senha: "",
      mensagemErro: "",
      conexaoApi: "http://192.168.1.33:5000"
    }
  }

  _fazerLogin(evento) {
    evento.preventDefault();

    Axios.post("http://192.168.56.1:5000/api/login/usuario", {
      nomeUsuario: this.state.nome,
      senha: this.state.senha
    }).then(data => {
      console.log(data)
      localStorage.setItem("Usuario-Pizzaria", data.data.token)
      this.props.history.push("/pizzarias")
    })
    .catch(erro => {
      this.setState({mensagemErro : "O email ou a senha estão incorretos"})
      console.log(erro)
    })
  }

  _atualizaEstado(evento) {
    evento.preventDefault();
    this.setState({[evento.target.name] : evento.target.value})
  }

  render() {
    return(
      <form onSubmit={this._fazerLogin.bind(this)}>
        <input name="nome" onChange={this._atualizaEstado.bind(this)} placeholder="Insira seu nome"/>
        <input name="senha" onChange={this._atualizaEstado.bind(this)} placeholder="Insira sua senha"/>
        <p>{this.state.mensagemErro}</p>
        <button type="submit">Login</button>
      </form>
    );
  }
}

export default Login;