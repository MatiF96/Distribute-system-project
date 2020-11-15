import React from 'react';
import {Switch, Route} from "react-router-dom";
import Home from '../../containers/Home';
import LoginForm from "../../containers/LoginForm";
import RegisterForm from "../../containers/RegisterForm";
import Movies from '../../containers/Movies';
import Movie from '../Movie';
import Halls from '../../containers/Halls';
import Hall from '../Hall';

const AppRouter = () => {
  return (
    <Switch>
        <Route exact path='/' component={Home} />

        <Route exact path='/login' component={LoginForm} />
        <Route exact path='/register' component={RegisterForm} />

        <Route exact path='/movies' component={Movies} />
        <Route path='/movies/:id' component={Movie} />
        <Route exact path='/halls' component={Halls} />
        <Route path="/halls/:id" component={Hall} />

        <Route path="*" component={Home} />
    </Switch>
)};

export default AppRouter;