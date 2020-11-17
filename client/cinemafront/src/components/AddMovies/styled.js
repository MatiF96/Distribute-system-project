import styled from 'styled-components'
import Input from '@material-ui/core/Input';
import { Button } from '@material-ui/core';

export const Container = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    margin: 10px;
    padding: 10px;
    min-width: 400px;
    background: #ff99bb;
    border-radius: 30px;
`

export const Title = styled.p`
    display: flex;
    justify-content: center;
    font-weight: bold;
    font-size: 1.8em;
    margin: 15px;
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