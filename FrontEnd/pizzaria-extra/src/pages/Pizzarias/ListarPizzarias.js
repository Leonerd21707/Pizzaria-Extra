import React, { Component } from "react";

class ListaPizzarias extends Component {
  constructor() {
    super();
    this.state = {
      nome: "",
      senha: "",
      mensagemErro: ""
    }
  }

  render() {
    return(
      <h1>Lista de pizzarias</h1>
    );
  }
}

export default ListaPizzarias;