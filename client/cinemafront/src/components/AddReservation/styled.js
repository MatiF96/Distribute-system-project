import styled from 'styled-components'
import { Button } from '@material-ui/core';

export const Container = styled.div`
    display: flex;
    justify-content: center;
`

export const CenterContainer = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    background: #ff80aa;
    min-width: 1000px;
    padding: 20px 50px 50px 30px;
`

export const List = styled.ul`
    display: flex;
    justify-content: center;
    width:  100%;
    flex-direction: row;
    flex-wrap: wrap;
    margin: 10px;
    padding: 20px;
    background: #ff99bb;
    border-radius: 30px;
`

export const Title = styled.p`
    display: flex;
    justify-content: center;
    font-weight: bold;
    font-size: 2em;
    margin: 15px;
`

export const Seat = styled.li`
    display: flex;
    width: 9%;
    margin: 4px;
    font-weight: bold;
    font-size: 1.4em;
    justify-content: center;
    align-items: center;
    min-width: 40px;
    min-height: 40px;
    background: ${props => props.isTaken ? "#ff4d94" : "#ff99dd"};
    border: 1px solid black;
    border-radius: 10px;
    cursor: pointer;

    &:hover {
        background: ${props => props.isTaken ? "#ff4d94" : "#ffb3e6"};
    }
`

export const StyledButton = styled(Button)`
    &&{
        min-width: 240px;
        margin: 20px;
        padding: 10px;
        background: #ffb3d9;
        font-size: 1.4em;
        font-weight: bold;
        color: #e6e6e6;
        border-radius: 20px;
    }
`

export const Display = styled.div`
    display: flex;
    justify-content: center;
    width: 100%;
    min-height: 20px;
    margin: 20px;
    background: white;
    color: black;
    border: 1px solid black;
    border-radius: 5px;

`