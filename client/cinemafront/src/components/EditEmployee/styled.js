import styled from 'styled-components'
import { Button } from '@material-ui/core';

export const Container = styled.div`
    display: flex;
    flex-direction: column;
    align-items: center;
    margin: 20px;
    padding: 10px;
    border-radius: 20px;
`

export const Wrapper = styled.div`
    display: flex;
    flex: 1;
    width: 800px;
    background:  #ff99dd;
    align-items: center;
    justify-content: center;
    padding: 20px;
    border-radius: 20px;
    font-size: 1.8em;
`

export const Title = styled.h1`
    display: flex;
    flex: 1;
    font-weight: bold;
    font-size: 1em;
    margin: 5px;
    white-space: nowrap;
`

export const StyledButton = styled(Button)`
    &&{
        width: 200px;
        margin:20px;
        padding: 10px;
        background: #ffb3e6;
        font-size: 0.8em;
    }
`

export const CurrentButton = styled(StyledButton)`
    &&{
        background: #ff66cc;
    }
`
