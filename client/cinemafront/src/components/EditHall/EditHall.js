import { Container, Title } from './styled';
import { useEffect, useState } from 'react';
import HallsApi from "../../api/HallsApi";
import Input from '@material-ui/core/Input';

const EditHall = ({ currentHall, refreshHall }) => {
  const [name, setName] = useState('');

  useEffect(() =>{
    setName(currentHall.name)
    // eslint-disable-next-line
  },[])

  const handleSubmit = (e) => {
    e.preventDefault()
    
    let data = {
      name: name
    };

    HallsApi.update(currentHall.id,data)
    .then((res) => {
      refreshHall()
      setName("")
      console.log(res);
    })
    .catch(e => {
      console.log(e);
    });
  }

  const handleChange = (e) => {
    setName(e.target.value)
  }
    return (
      <Container>
        <Title>Edytuj salę:</Title>
          <form onSubmit={handleSubmit}>
            <Input
              type="text"
              id="title"
              name="title"
              value={name}
              onChange={handleChange}
              placeholder="Nazwa sali"
            />
          </form>
      </Container>
  )};
  
  export default EditHall;