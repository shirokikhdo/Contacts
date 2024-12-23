import React from "react";
import RowTableContact from "./components/RowTableContact";

const TableContact = (props) =>{
    return(
        <table className="table table-hover">
            <thead>
              <tr>
                <th>#</th>
                <th>Имя</th>
                <th>Email</th>
              </tr>
            </thead>
            <tbody>
              {
                props.contacts.map(
                  contact =>
                    <RowTableContact 
                      id={contact.id}
                      name = {contact.id}
                      email = {contact.email}/>
                )
              }
            </tbody>
          </table>
    )
}

export default TableContact;