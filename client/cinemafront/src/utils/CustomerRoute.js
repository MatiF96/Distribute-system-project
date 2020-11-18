import AuthService from "../components/AuthService"
import { ADMIN, EMPLOYEE, CUSTOMER } from "./Roles"
import { Route, Redirect } from "react-router-dom"

export const CustomerRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={(props) => (
      AuthService.getUserRole() === ADMIN || AuthService.getUserRole() === EMPLOYEE || AuthService.getUserRole() === CUSTOMER 
        ? <Component {...props} />
        : <Redirect to='/login' />
    )} />
  )