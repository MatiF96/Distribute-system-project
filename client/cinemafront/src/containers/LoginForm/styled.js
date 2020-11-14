import styled from 'styled-components'
import { TextField, Button } from '@material-ui/core';

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

export const StyledForm = styled.form`
    width: 100px;
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    padding: 10px;
    background: #ff99bb;
    border-radius: 20px;
    margin: 20px;
`

export const Text = styled(TextField)`
    &&{
        width: 400px;
        padding: 20px;
        background: #ffb3d9;
        border-radius: 20px;
        margin-bottom: 10px;
    }
`

export const StyledButton = styled(Button)`
    &&{
        width: 200px;
        margin:20px;
        padding: 10px;
        background: #ffb3d9;
        font-size: 1.2em;
    }
`

export const Label = styled.p`
    font-size: 1.4em;
    font-weight: bold;
`