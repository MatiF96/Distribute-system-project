import React, { useState } from 'react';
import {Container, CenterContainer, StyledForm,  Text, StyledButton, Label, Alert} from './styled';
import AuthService from "../../components/AuthService";
import { withRouter } from "react-router-dom"

const RegisterForm = (props) => {

  const [login, setLogin] = useState('')
  const [password, setPassword] = useState('')
  const [showAlert, setShowAlert] = useState(false)

  const handleSubmit = (e) => {
    e.preventDefault()
    
    AuthService.register(login,password).then(
    () => {
      props.history.push("/");
    },
    error => {
      console.log(error)
      setShowAlert(true)
    })
  }

  const handleChange = (e) => {
    const { target } = e;
    const { name, value } = target;

    name==="login"?
    setLogin(value):
    setPassword(value)
  };

  return (
    <Container>
      <CenterContainer>
          <StyledForm onSubmit={handleSubmit}>
              <Label type="text">Login:</Label>
              <Text 
              type="text"
              id="login"
              name="login"
              value={login}
              onChange={handleChange}
              placeholder="Wpisz nowy login"
              />
              <Label>Hasło:</Label>
              <Text 
              type="password"
              id="password"
              name="password"
              value={password}
              onChange={handleChange}
              placeholder="Wpisz hasło"
              />
              <StyledButton type="submit" >Zaarejestruj</StyledButton>
              {showAlert?<Alert>Niepoprawne dane!</Alert>:null}
          </StyledForm>
      </CenterContainer>
    </Container>
)};

export default withRouter(RegisterForm);