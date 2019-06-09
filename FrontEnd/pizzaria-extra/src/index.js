import React from 'react';
import ReactDOM from 'react-dom';
import { Route, BrowserRouter as Router, Switch, Redirect } from "react-router-dom";
import * as serviceWorker from './serviceWorker';
import Login from "./pages/Usuarios/Login"
import ListarPizzarias from "./pages/Pizzarias/ListarPizzarias.js"
import CadastrarPizzarias from "./pages/Pizzarias/CadastrarPizzarias"
import { usuarioAutenticado } from "../src/services/auth";

const Permissao = ({ component: Component }) => (
  <Route
    render={props => usuarioAutenticado() ?
      (<Component {...props} />) :
      (<Redirect to={{ pathname: "/" }} />)
      
    }
  />
);

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Login} />
        <Permissao exact path="/pizzarias/cadastro" component={CadastrarPizzarias} />
        <Route exact path="/pizzarias" component={ListarPizzarias} />
      </Switch>
    </div>
  </Router>
);

ReactDOM.render(routing, document.getElementById("root"));


// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();