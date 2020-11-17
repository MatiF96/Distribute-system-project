import styled from 'styled-components'
import Input from '@material-ui/core/Input';
import { Button } from '@material-ui/core';

export const Container = styled.div`
    display: flex;
    width: 90%;
    flex-direction: column;
    align-items: center;
    background:  #ff99dd;
    border-radius: 30px;
    margin-top: 30px;
    padding: 10px;
`

export const InnerContainer = styled.div`
    display: flex;
    justify-content: center;
    align-items: center;
    width: 100%;
    margin: 10px;
    border-radius: 20px;
`

export const Title = styled.p`
    display: flex;
    justify-content: center;
    font-weight: bold;
    font-size: 2.6em;
    margin: 20px 20px;
`

export const StyledForm = styled.form`
    display: flex;
    flex-direction: column;
    justify-content: center;
`

export const StyledInput = styled(Input)`
    display: flex;
    justify-content: center;
    font-weight: bold;
    font-size: 1.6em;
    margin: 5px;
`

export const StyledButton = styled(Button)`
    &&{
        width: 300px;
        height: 60px;
        margin:20px;
        padding: 10px;
        background: #ffb3d9;
        font-size: 1.4em;
        font-weight: bold;
        color: #e6e6e6;
        border-radius: 20px;
    }
`

export const List = styled.ul`
    display: flex;
    flex: 1 1;
    flex-direction: column;
    width: 100%;
    flex-wrap: wrap;
    list-style:none;
    align-items: center;
`

export const Item = styled.li`
    display: flex;
    width: 80%;
    background: #ff80b3;
    font-size: 1.8em;
    min-height: 50px;
    min-width: 150px;
    flex-grow: 1;
    justify-content: center;
    align-items: center;
    flex-shrink: 0;
    padding: 15px 10px;
    margin: 6px;
    border-radius: 30px;
    cursor: pointer;

    &:hover {
        background: #ffb3e6;
    }
`

export const ClickedItem = styled(Item)`
    background: #ff4d94;
`