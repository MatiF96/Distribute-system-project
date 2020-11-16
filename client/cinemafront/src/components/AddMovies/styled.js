import styled from 'styled-components'
import Input from '@material-ui/core/Input';
import { Button } from '@material-ui/core';

export const Container = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    margin: 20px;
    padding: 10px;
    width: 280px;
    background: #ff99bb;
    border-radius: 20px;
`

export const Title = styled.p`
    display: flex;
    justify-content: center;
    font-weight: bold;
    font-size: 1.6em;
    margin: 5px;
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
        width: 200px;
        margin:20px;
        padding: 10px;
        background: #ffb3d9;
        font-size: 0.8em;
    }
`