import React, { Component } from "react";

class CadastroPizzarias extends Component {
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
      <h1>Cadastro de pizzarias</h1>
    );
  }
}

export default CadastroPizzarias;