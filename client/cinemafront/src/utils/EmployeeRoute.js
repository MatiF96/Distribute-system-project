import AuthService from "../components/AuthService"
import { ADMIN, EMPLOYEE} from "./Roles"
import { Route, Redirect } from "react-router-dom"

export const EmployeeRoute = ({ component: Component, ...rest }) => (
    <Route {...rest} render={(props) => (
      AuthService.getUserRole() === ADMIN || AuthService.getUserRole() === EMPLOYEE
        ? <Component {...props} />
        : <Redirect to='/login' />
    )} />
  )