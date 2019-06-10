import React, { Component } from "react";
import {Token} from "../../services/token";
import Axios from "axios";

class CadastroPizzarias extends Component {
  constructor() {
    super();
    this.state = {
      nomePizzaria: "",
      idCategoria: "",
      telefone: "",
      opcaoVegana: false,
      mensagemErro: "",
      mensagemSucesso: "",
      conexaoApi: "http://192.168.56.1:5000/api"
    }
    this._atualizaEstado = this._atualizaEstado.bind(this)
  }

  _cadastrarPizzarias(evento) {
    this._verificarUsuario();
    evento.preventDefault();
    fetch(this.state.conexaoApi + "/pizzarias/cadastro", {
      method: "post",
      mode: "cors",
      body: JSON.stringify({
        nomePizzaria: this.state.nomePizzaria,
        telefone: parseInt(this.state.telefone),
        idCategoria: parseInt(this.state.idCategoria),
        opcaoVegana: Boolean(this.state.opcaoVegana)
      }),
        headers: new Headers({
          "Content-type" : "application/json",
          "Authorization" : "Bearer " + localStorage.getItem("Usuario-Pizzaria"),
        })
      }).catch(erro => console.log(erro))
  }

  _atualizaEstado(evento) {
    evento.preventDefault();
    this.setState({[evento.target.name] : evento.target.value})
  }

  _atualizaEstadoOpcaoVegana(evento) {
    if (this.state.opcaoVegana === true) {
      this.setState({[evento.target.name] : false})
    } else if (this.state.opcaoVegana === false) {
      this.setState({[evento.target.name] : true})
    }
  }

  _verificarUsuario() {
    if (Token() === null) {
      this.props.history.push("/")
    }
  }

  componentDidMount() {
    this._verificarUsuario();
  }

  render() {
    return(
      <div>
        <h1>Cadastro de pizzarias</h1>
        <a href="/pizzarias">Ver a lista de pizzarias</a>
        <form onSubmit={this._cadastrarPizzarias.bind(this)}>
          <input name="nomePizzaria" defaultValue={this.state.nomePizzaria} onChange={this._atualizaEstado.bind(this)} placeholder="Insira o nome da pizzaria"/>
          <input name="telefone" onChange={this._atualizaEstado.bind(this)} placeholder="Insira o telefone da pizzaria"/>
          <select name="idCategoria" value={this.state.idCategoria} onChange={this._atualizaEstado.bind(this)}>
            <option value={1}>$ (até 30 reais a pizza)</option>
            <option value={2}>$$ (de 31 até 50)</option>
            <option value={3}>$$$ (acima de 50 reais o valor da pizza)</option>
          </select>
          <label>Opção vegana: </label>
          <input name="opcaoVegana" type="checkbox" checked={this.state.opcaoVegana} onChange={this._atualizaEstadoOpcaoVegana.bind(this)}/>
          <p>{this.state.mensagemErro}</p>
          <p>{this.state.mensagemSucesso}</p>
          <button type="submit">Cadastrar</button>
        </form>
      </div>
    );
  }
}

export default CadastroPizzarias;