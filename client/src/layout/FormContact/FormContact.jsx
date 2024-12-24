import React, { useState } from "react";

const FormContact = (props) => {

    const [contactName, setContactName] = useState("");
    const [contactEmail, setContactEmail] = useState("");

    const submit = () => {
        if(contactName.length === 0 
            || contactEmail.length === 0)
            return;
        props.addContact(contactName, contactEmail);
    }

    return(
        <div>
            <div className="mb-3">
                <form>
                    <div className="mb-3">
                        <label className="form-label">Введите имя:</label>
                        <textarea 
                                className="form-control"
                                rows={1} 
                                placeholder="Например qwerty"
                                onChange={(e) => {setContactName(e.target.value)}}/>
                    </div>
                    <div className="mb-3">
                        <label className="form-label">Введите Email:</label>
                        <input 
                            className="form-control"
                            type="text" 
                            placeholder="Например qwerty@mail.ru"
                            onChange={(e) => {setContactEmail(e.target.value)}}/>
                    </div>
                </form>
            </div>

            <div>
                <button
                    className="btn btn-primary"
                    onClick={() => {submit()}}>
                    Добавить контакт
                </button>
          </div>
        </div>
    )
}

export default FormContact;