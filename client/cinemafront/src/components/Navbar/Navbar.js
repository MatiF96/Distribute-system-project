import React, { useContext } from 'react';
import NavItem from '../NavItem'
import {Container, Menu} from './styled'
import {PagesContext} from '../../contexts/PagesContext';

const Navbar = () => {
  const { pages } = useContext(PagesContext);

  return (
  <Container>
      <Menu>
        {pages.map((page, index) => <NavItem key={page.url} href={page.url}>{page.label}</NavItem>)}
      </Menu>
  </Container>
)};

export default Navbar;
