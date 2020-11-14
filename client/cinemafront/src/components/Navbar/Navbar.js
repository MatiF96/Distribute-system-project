import React, { useContext } from 'react';
import NavItem from '../NavItem'
import {Container, Menu, AuthContainer, StyledButton} from './styled'
import {PagesContext} from '../../contexts/PagesContext';
import {withRouter} from "react-router-dom"
import { StyledLink } from '../NavItem/styled';
import AuthService from "../AuthService";

const Navbar = (props) => {
  const { pages } = useContext(PagesContext);

  const handleLogout = () => {
    AuthService.logout()
    props.history.push("/");
  }
  return (
  <Container>
      <Menu>
        {pages.map((page, index) => <NavItem key={page.url} href={page.url}>{page.label}</NavItem>)}
      </Menu>
      <AuthContainer>
        {AuthService.getCurrentUser()?
        <>
        <p>Zalogowany jako {AuthService.getCurrentUser().username}</p>
        <StyledButton onClick={handleLogout}>Wyloguj</StyledButton>
        </>:
        <>
        <StyledLink to="/login">
          <StyledButton>Zaloguj</StyledButton>
        </StyledLink>
        <StyledLink to="/register">
          <StyledButton>Rejestracja</StyledButton>
        </StyledLink>
        </>}
      </AuthContainer>
  </Container>
)};

export default withRouter(Navbar);
