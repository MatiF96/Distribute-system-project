import React, {useContext} from 'react';
import {Switch, Route, Router} from "react-router-dom";
import Home from '../../containers/Home';
import Movies from '../../containers/Movies';
import Halls from '../../containers/Halls';
import Hall from '../Hall';

const AppRouter = () => {
  return (
    <Switch>
        <Route exact path='/' component={Home} />
        <Route exact path='/movies' component={Movies} />
        <Route exact path='/halls' component={Halls} />
        <Route path="/halls/:id" component={Hall} />
    </Switch>
)};

export default AppRouter;