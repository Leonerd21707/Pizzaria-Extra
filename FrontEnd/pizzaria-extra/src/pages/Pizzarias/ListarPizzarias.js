import React, { Component } from "react";
import {Token} from "../../services/token";
import Axios from "axios";

class ListaPizzarias extends Component {
  constructor() {
    super();
    this.state = {
      listaPizzarias: [],
      mensagemErro: "",
      conexaoApi: "http://192.168.56.1:5000/api"
    }
  }

  _listarPizzarias() {
    Axios.get(this.state.conexaoApi + "/pizzarias").then(dados => {
      this.setState({listaPizzarias : dados.data})
    }).catch(erro => {
      this.setState({mensagemErro : "Um erro ocorreu para carregas as pizzarias, tente mais tarde."})
    })
  }

  _listarPizzariasComCategorias() {
    Axios.get("http://192.168.56.1:5000/api/pizzarias/categorias").then(dados => {
      this.setState({listaPizzarias : dados.data})
    }).catch(erro => {
      this.setState({mensagemErro : "Um erro ocorreu para carregas as pizzarias, tente mais tarde."})
    })
  }

  _verificarUsuario() {
    if (Token() === null) {
      this.props.history.push("/")
    } 
  }

  componentDidMount() {
    this._listarPizzariasComCategorias();
    this._verificarUsuario()
  }

  render() {
    return(
      <div>
        <h1>Lista de pizzarias</h1>
        <a href="/pizzarias/cadastro">Cadastrar uma pizzaria</a>
        <p>{this.state.mensagemErro}</p>
        <table>
          <thead>
            <tr>
              <th>Número da pizzaria</th>
              <th>Nome da pizzaria</th>
              <th>Categoria da pizzaria</th>
              <th>Telefone da pizzaria</th>
              <th>Possui opção vegana?</th>
            </tr>
          </thead>
          <tbody>
          {this.state.listaPizzarias.map(function (pizzaria) {
            console.log(pizzaria)
            if (pizzaria.opcaoVegana === true) {
              pizzaria.opcaoVegana = "Sim"
            } else {
              pizzaria.opcaoVegana = "Não"
            }
            return(
              <tr key={pizzaria.idPizzaria}>
                <td>{pizzaria.idPizzaria}</td>
                <td>{pizzaria.nomePizzaria}</td>
                <td>{pizzaria.idCategoriaNavigation.nomeCategoria}</td>
                <td>{pizzaria.telefone}</td>
                <td>{pizzaria.opcaoVegana}</td>
              </tr>
            )
          })}
          </tbody>
        </table>
      </div>
    );
  }
}

export default ListaPizzarias;