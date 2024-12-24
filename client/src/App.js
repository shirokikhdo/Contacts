import React, {useState} from "react";
import TableContact from "./layout/TableContact/TableContact";
import FormContact from "./layout/FormContact/FormContact";

const App = () => {

  const[contacts, setContacts] = useState(
    [
      {id:1, name:"имя 1", email:"почта 1"},
      {id:2, name:"имя 2", email:"почта 2"},
      {id:3, name:"имя 3", email:"почта 3"}
    ]
  )
  
  const addContact = (contactName, contactEmail) => {
    const newId = Math.max(...contacts.map(e => e.id)) + 1;
    const item = {
      id: newId, 
      name: contactName, 
      email: contactEmail
    };
    setContacts([...contacts, item]);
  }

  const deleteContact = (id) => {
    setContacts(contacts.filter(x=>x.id !== id));
  }

  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact
            contacts={contacts}
            deleteContact={deleteContact}/>
          <FormContact addContact={addContact}/>
        </div>
      </div>
    </div>
  );
}

export default App;