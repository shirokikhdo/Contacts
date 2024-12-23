import TableContact from "./layout/TableContact/TableContact";

const contacts = [
  {id:1, name:"имя 1", email:"почта 1"},
  {id:2, name:"имя 2", email:"почта 2"},
  {id:3, name:"имя 3", email:"почта 3"}
]

const addContact = () => {
  const item = {
    id:Math.floor(Math.random() * 100), 
    name:"имя 3", 
    email:"почта 3"};
  contacts.push(item);
  console.log(contacts);
}

const App = () => {
  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact contacts={contacts}/>
          <div>
            <button
              className="btn btn-primary"
              onClick={() => {addContact()}}>
                Добавить контакт
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;