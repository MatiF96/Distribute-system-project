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
import Reservation from '../../components/Reservation';
import { EmployeeRoute } from '../../utils/EmployeeRoute';
import { CustomerRoute } from '../../utils/CustomerRoute';

const AppRouter = () => {
  return (
    <Switch>
        <Route exact path={['/','/showings']} component={Showings} />

        <Route exact path='/login' component={LoginForm} />
        <Route exact path='/register' component={RegisterForm} />

        <CustomerRoute exact path='/reservation' component={Reservation} />
        <CustomerRoute path="/reservation/:id" component={Reservation} />

        <EmployeeRoute exact path='/movies' component={Movies} />
        <EmployeeRoute path='/movies/:id' component={Movie} />
        <EmployeeRoute exact path='/halls' component={Halls} />
        <EmployeeRoute path="/halls/:id" component={Hall} />
        <EmployeeRoute exact path='/employees' component={Employees} />

        <Route path="*" component={Showings} />
    </Switch>
)};

export default AppRouter;