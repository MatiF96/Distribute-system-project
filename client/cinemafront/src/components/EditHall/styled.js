import styled from 'styled-components'
import Input from '@material-ui/core/Input'
import { Button } from '@material-ui/core';

export const Container = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    margin: 20px;
    padding: 10px;
    width: 280px;
    border-radius: 20px;
`

export const StyledForm = styled.form`
    display: flex;
    flex-direction: column;
    justify-content: center;
`

export const Title = styled.p`
    display: flex;
    justify-content: center;
    font-weight: bold;
    font-size: 1.4em;
    margin: 15px;
`

export const StyledInput = styled(Input)`
    display: flex;
    min-width: 250px;
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