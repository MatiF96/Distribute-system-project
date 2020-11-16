import styled from 'styled-components'
import { Link } from 'react-router-dom';

export const Container = styled.div`
    display: flex;
    justify-content: center;
    min-height: 93vh;
`

export const CenterContainer = styled.div`
    display: flex;
    width: 1300px;
    flex-direction: column;
    align-items: center;
    background: #ff80aa;
    padding: 0 100px;
`

export const Wrapper = styled.div`
    display: flex;
    flex-direction: column;
    width: 100%;
    padding: 10px;
    align-items: center;
`

export const Title = styled.h1`
    font-size: 2.4em;
    padding: 15px;
`

export const List = styled.ul`
    display: flex;
    width: 100%;
    flex-wrap: wrap;
    list-style:none;
    justify-content: center;
`

export const StyledLink = styled(Link)`
    display: flex;
    width: 80%;
    font-size: 1.8em;
    min-height: 100px;
    justify-content: center;
    align-items: center;
    flex-shrink: 0;
    background:  #ff99dd;
    padding: 10px;
    margin: 5px;
    border-radius: 20px;
    cursor: pointer;

    &:hover {
        background: #ffb3e6;
    }
`