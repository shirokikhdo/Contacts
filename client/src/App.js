import TableContact from "./layout/TableContact/TableContact";

const contacts = [
  {id:1, name:"имя 1", email:"почта 1"},
  {id:2, name:"имя 2", email:"почта 2"},
  {id:3, name:"имя 3", email:"почта 3"}
]

const App = () => {
  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>
        <div className="card-body">
          <TableContact contacts={contacts}/>
        </div>
      </div>
    </div>
  );
}

export default App;