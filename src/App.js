import './App.css';

function App() {

  class Persone{//создаем класс 'персона человека'
    constructor(name, age){
      this.name = name;
      this.age = age
    };//получаем 2 атрибута 'имя и возраст человека'

    set name(value){//получаем входные данные человека и редактируем их  
      const firstLetter = value[0].toUpperCase();//делаем первую букву имени заглавной
      const nextAllLetter = value.slice(1).toLowerCase();//остальную часть с маленькой
      this._name = `${firstLetter}${nextAllLetter}`//теперь полученные данные всегда хранят имя с заглавной буквы
    };

    get name(){//оставляем стандартные настройки выходных данных
      return this._name
    };

    eat(){//создаем метод, выводщий строку 'Я ем' 
      console.log('Я ем')
    };

    info(){//создаем метод, выводящий информацию о человеке 
      console.log(`Меня зовут: ${this._name}, мне ${this.age} лет`)
    };
  };

  const User = new Persone('данил', 17);//создаем объект человека унаследовавший настройки класса Persone

  class Developer extends Persone{//создаём класс разработчик, прототипом которого является класс персона человека
    constructor(name, age, city){//добавляем новый атрибут 'город проживания'
      super(name, age);//наследуем инструкцию имени и возраста из прототипа 
      this.city = city
    }

    set city(value){//получаем входные данные города, в котором работет разработчик и редактируем их  
      const firstLetter = value[0].toUpperCase();//делаем первую букву имени заглавной
      const nextAllLetter = value.slice(1).toLowerCase();//остальную часть с маленькой
      this._city = `${firstLetter}${nextAllLetter}`//теперь полученные данные всегда хранят название города с заглавной буквы
    };

    get city(){//изменяем выходные данные, добовляем 'г.' перед городом
      return `г. ${this._city}`
    };

    eat(){//изменяем метод 'разработчик ест, а после идёт писать код'
      super.eat();//наследуем метод прототипа
      console.log('Когда я поем, пойду писть код')
    }

    info(){//изменяем информацию о разработчике, добавляем город в котором он работает
      console.log(`Меня зовут: ${this._name}, мне ${this.age} лет, я работаю в ${this.city}`)
    }
    
    writeCode(){//добавляем метод 'пишу код'
      console.log('Пишу код')
    }
  };

  const UserTwo = new Developer('иван', 20, 'екатеринбург');//создаем обект разработчика, наследовавший класс персоны и разработчика 
  
  //проверяем что всё работет 
  User.info();
  User.eat();
  UserTwo.info();
  UserTwo.eat();
  UserTwo.writeCode();
  return (
    <div className="App">
    </div>
  );
}

export default App;
