import styled from 'styled-components'
import Input from '@material-ui/core/Input';
import { Button } from '@material-ui/core';

export const Container = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    margin: 20px;
    padding: 0px;
    width: 280px;
    border-radius: 20px;
`

export const FormContainer = styled.form`
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
`

export const Title = styled.h1`
    display: flex;
    margin: 10px;
    font-weight: bold;
    font-size: 1.2em;
    white-space: nowrap;
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
        min-width: 220px;
        max-height: 50px;
        margin: 30px;
        padding: 30px;
        background: #ffb3d9;
        font-size: 0.8em;
        font-weight: bold;
        color: #e6e6e6;
        border-radius: 20px;
    }
`