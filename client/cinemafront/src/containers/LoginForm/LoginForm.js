import React, { useState } from 'react';
import {Container, CenterContainer, StyledForm,  Text, StyledButton, Label} from './styled';
import AuthService from "../../components/AuthService";
import { withRouter } from "react-router-dom"

const LoginForm = (props) => {

  const [login, setLogin] = useState('')
  const [password, setPassword] = useState('')

  const handleSubmit = (e) => {
    e.preventDefault()
    
    AuthService.login(login,password).then(
    () => {
      props.history.push("/");
    },
    error => {
      console.log(error)
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
              placeholder="Podaj login"
              />
              <Label>Hasło:</Label>
              <Text 
              type="password"
              id="password"
              name="password"
              value={password}
              onChange={handleChange}
              placeholder="Podaj hasło"
              />
              <StyledButton type="submit" >Zaloguj</StyledButton>
          </StyledForm>
      </CenterContainer>
    </Container>
)};

export default withRouter(LoginForm);