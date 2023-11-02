![TV-program1](https://github.com/AnastasiaMaslova1/TV-program/assets/128154905/d053e426-e662-4cb1-8819-247417884d93)
# TV-program
1. Общие требования:

1.1. Интерфейс: Приложение должно предоставлять пользователю современный и интуитивно понятный интерфейс, способствующий быстрой и удобной навигации.

1.2. Языковая поддержка: Интерфейс приложения должен поддерживать русский язык. Возможность ручного переключения языка должна также быть реализована.

1.3. Базы данных: Приложение должно использовать надежные и масштабируемые базы данных для хранения информации о телепередачах, пользовательских учетных записях и другой сопутствующей информации.

2. Функциональные требования:

2.1. Регистрация пользователя:

При регистрации необходимы следующие поля: уникальное имя пользователя или электронный адрес/телефон и пароль. При регистрации все поля должны быть проверены на корректность (например, формат электронной почты, сложность пароля).
Пользователь должен получать уведомление при успешной регистрации или о возникших ошибках. После регистрации на указанный электронный адрес или телфон должен приходить код для подтверждения.

2.2. Логин и логаут пользователя:

При входе в систему требуется ввод имени пользователя или электронного адреса и пароля, и приложение должно предоставлять опцию "Запомнить меня" для удобства повторного входа.
При неверном вводе учетных данных пользователь должен получать соответствующее сообщение.
Пользователь должен иметь возможность выйти из системы.

2.3. (INDEX) Просмотр списка записей:

Пользователи должны видеть актуальный список телепередач, упорядоченный по дате и времени.
Возможность фильтрации списка телепередач по дате, времени и каналу трансляции.
Каждая запись в списке должна отображать название передачи, краткое описание, время и дату показа.

2.4. (CREATE) Создание записи:

Только администраторы имеют право создавать новые записи о телепередачах.
Форма для ввода информации о новой телепередаче, включая название, дату и время показа, краткое описание, канал трансляции и возможно изображение или постер передачи.

2.5. (READ) Просмотр деталей записи:

Пользователи должны видеть всю доступную информацию о передаче, включая длительность, актеров, жанр и т.д.

2.6. (UPDATE) Редактирование записи:

Только администраторы могут редактировать информацию о телепередаче.
Функциональность должна предоставлять возможность корректировать любую информацию о передаче, а также добавлять новые данные.

2.7. (DELETE) Удаление записи:

Только администраторы имеют доступ к функции удаления телепередачи.
Перед удалением необходимо запрашивать подтверждение действия у администратора.
