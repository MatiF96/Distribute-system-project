import styled from 'styled-components'

export const Container = styled.nav`
  display: flex;
  position: sticky;
  top:0;
  width:100%;
  height: 65px;
  font-size: 1.8rem;
  color: #f1f1f1;
  background: #ff3377;
  border-bottom: 2px solid #f1f1f1;
  justify-content: space-between;
  z-index: 999;
`

export const Menu = styled.ul`
    list-style-type: none;
    display: flex;
    flex: 1 1;
    flex-wrap: wrap;
    justify-content: space-around;
`
