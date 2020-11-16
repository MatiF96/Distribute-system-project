import React from 'react';
import {Switch, Route} from "react-router-dom";
import Showings from '../../containers/Showings';
import LoginForm from "../../containers/LoginForm";
import RegisterForm from "../../containers/RegisterForm";
import Movies from '../../containers/Movies';
import Movie from '../Movie';
import Halls from '../../containers/Halls';
import Hall from '../Hall';
import Employees from '../../containers/Employees';

const AppRouter = () => {
  return (
    <Switch>
        <Route exact path={['/','/showings']} component={Showings} />

        <Route exact path='/login' component={LoginForm} />
        <Route exact path='/register' component={RegisterForm} />

        <Route exact path='/movies' component={Movies} />
        <Route path='/movies/:id' component={Movie} />
        <Route exact path='/halls' component={Halls} />
        <Route path="/halls/:id" component={Hall} />
        <Route exact path='/employees' component={Employees} />

        <Route path="*" component={Showings} />
    </Switch>
)};

export default AppRouter;