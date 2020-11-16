import styled from 'styled-components'
import { Link } from 'react-router-dom';
import DeleteOutlineOutlinedIcon from '@material-ui/icons/DeleteOutlineOutlined';

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
    align-items: center;
`

export const StyledLink = styled(Link)`
    display: flex;
    flex-basis: 100%;
    font-size: 1.8em;
    min-height: 150px;
    min-width: 150px;
    flex-grow: 1;
    justify-content: center;
    align-items: center;
    flex-shrink: 0;
    background:  #ff99dd;
    padding: 10px;
    margin: 5px;
    border-radius: 20px;

    &:hover {
        background: #ffb3e6;
    }
`

export const Row = styled.div`
    display: flex;
    flex-basis: 100%;
    justify-content: center;
    align-items: center;
`

export const DeleteIcon = styled(DeleteOutlineOutlinedIcon)`
    cursor: pointer;
    && {
    margin-left: 20px;
    font-size: 50px;
    }
`