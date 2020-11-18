import styled from 'styled-components'

export const Container = styled.div`
    display: flex;
    width: 100%;
    justify-content: center;
    height: 100vh;
`

export const CenterContainer = styled.div`
    display: flex;
    width: 1500px;
    flex-direction: column;
    align-items: center;
    background: #ff80aa;
`

export const Wrapper = styled.div`
    display: flex;
    flex-direction: column;
    width: 100%;
    padding: 10px;
    align-items: center;
`

export const Alert = styled.h1`
    font-size: 2.4em;
    padding: 15px;
`

export const Item = styled.li`
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
    text-align: center;
    cursor: pointer;

    &:hover {
        background: #ffb3e6;
    }
`

export const BlockedItem = styled(Item)`
    background:  red;

    &:hover {
        background: red;
    }
`