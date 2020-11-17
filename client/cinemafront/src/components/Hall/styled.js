import styled from 'styled-components'
import DeleteOutlineOutlinedIcon from '@material-ui/icons/DeleteOutlineOutlined';

export const Container = styled.div`
    display: flex;
    flex-direction: column;
    font-size: 2em;
`
export const Wrapper = styled.div`
    display: flex;
    flex: 1;
    background:  #ff99dd;
    align-items: center;
    justify-content: center;
    padding: 20px;
    margin: 10px;
    border-radius: 30px;
`

export const Item = styled.span`
    padding: 25px;
`

export const Label = styled.p`
    font-weight:bold;
`

export const EditLabel = styled.p`
    font-weight:bold;
    cursor: pointer;
`

export const DeleteIcon = styled(DeleteOutlineOutlinedIcon)`
    cursor: pointer;
    && {
    font-size: 60px;
    }
`