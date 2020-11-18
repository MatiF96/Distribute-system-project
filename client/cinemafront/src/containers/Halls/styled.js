import styled from 'styled-components'
import { Link } from 'react-router-dom';

export const Container = styled.div`
    display: flex;
    justify-content: center;
    min-width: 740px;
`

export const CenterContainer = styled.div`
    display: flex;
    min-height: 100vh;
    width: 1500px;
    flex-direction: column;
    align-items: center;
    background: #ff80aa;
    padding: 10px 50px 50px 30px;
`

export const Wrapper = styled.div`
    display: flex;
    flex-direction: column;
    width: 100%;
    padding: 10px 30px;
    align-items: center;
`

export const Title = styled.h1`
    font-size: 2.6em;
    padding-bottom: 15px;
`

export const List = styled.ul`
    display: flex;
    width: 100%;
    flex-wrap: wrap;
    list-style:none;
    align-items: center;
`

export const StyledLink = styled(Link)`
    display: flex;
    flex-basis: 30%;
    font-size: 1.8em;
    min-height: 150px;
    min-width: 150px;
    flex-grow: 1;
    justify-content: center;
    align-items: center;
    flex-shrink: 0;
    background:  #ff99dd;
    padding: 10px;
    margin: 5px;
    border-radius: 25px;
    cursor: pointer;

    &:hover {
        background: #ffb3e6;
    }
`