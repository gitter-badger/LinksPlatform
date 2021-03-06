﻿namespace Platform.Links.DataBase.CoreUnsafe.Elements
{
    /// <summary>
    /// Инкапсулирует метод, читающий элемент.
    /// Метод получает адрес, значение, левое продолжение и правое продолжение элемента.
    /// Метод возвращает значение, определяющие, был ли прерван процесс чтения (Продолжен - True, Прерван - False).
    /// </summary>
    /// <typeparam name="TElement">Тип индекса (идентификатора/адреса) элемента.</typeparam>
    /// <param name="element">Сам элемент.</param>
    /// <param name="value">Элемент-значение.</param>
    /// <param name="left">Левый элемент-продолжение.</param>
    /// <param name="right">Правый элемент-продолжение.</param>
    /// <returns>True - чтение продолжается, False - чтение прервано.</returns>
    public delegate bool ElementReader<in TElement>(TElement element, TElement value, TElement left, TElement right);

    /// <summary>
    /// Представляет интерфейс для работы с базой данных (хранилищем)
    /// в формате Elements (хранилища элементов и составных элементов (последовательностей)).
    /// </summary>
    /// <typeparam name="TElement">Тип индекса (идентификатора/адреса) элемента.</typeparam>
    /// <remarks>Здесь располагается методы соотствующие шаблону Read-Write (RW).</remarks>
    public partial interface IElements<TElement>
    {
        /// <summary>
        /// Создаёт элемент (если он ещё не существует), либо возвращает индекс существующего элемента
        /// с указанными Left (продолжением слева), Value (значением) и Right (продолжением справа).
        /// </summary>
        /// <param name="left">Индекс левого (Left) элемента, который будет является продолжением создаваемого элемента влево.</param>
        /// <param name="value">Индекс элемента, который будет являться значением данного создаваемого элемента.</param>
        /// <param name="right">Индекс правого (Right) элемента, который будет являться продолжением создаваемого элемента вправо.</param>
        /// <returns>Индекс созданного или существующего элемента, с указанным Left (продолжением влево), Value (значением) и Right (продолжением вправо)</returns>
        /// <remarks>
        /// Традиционно последовательности (строки, массивы) и т.п. представлены в виде ссылок на их начало
        /// (может присутствовать информация о длине последовательности или есть соглашение о том, что символизирует окончание последовательности).
        /// Уникальность последовательностей не гарантируются, может существовать несколько одинаковых последовательностей.
        /// Чтобы узнать как взаимосвязаны эти последовательности необходимо выполнять дополнительные вычисления.
        /// Выделение памяти происходит по требованию, могут возникать проблемы с неравномерным выделением памяти.
        /// (В те места, где память высвободилась память нельзя разместить новые элементы без перемещение используемой памяти)
        /// Не хранятся обратные ссылки на указатели (что требует статического размещения информации в памяти, затрудняет её перемещение).
        /// </remarks>
        TElement Create(TElement left, TElement value, TElement right);

        /// <summary>
        /// Записывает в хранилище (базу данных) новый самостоятельный элемента (точку)
        /// и возвращает его адрес.
        /// </summary>
        /// <returns>Адрес (индекс) нового самостоятельного элемента (точки).</returns>
        TElement Write();

        /// <summary>
        /// Записывает в хранилище (базу данных) новый самостоятельный элемента (точку)
        /// в ячейку указанным адресом.
        /// </summary>
        /// <param name="address">Адрес (индекс) нового самостоятельного элемента (точки).</param>
        /// <remarks>
        /// Если используется пустой адрес - default(TElement), ты вызов этот метода эквивалентен вызову Write().
        /// TODO: Решить что будет происходить, когда в ячейке с указаным адресом уже существуют данные. Возможно это должно настраиваться.
        /// </remarks>
        void Write(TElement address);

        /// <summary>
        /// Перемещает 
        /// </summary>
        /// <param name="previousAddress"></param>
        /// <param name="newAddress"></param>
        void Write(TElement previousAddress, TElement newAddress);

        /// <summary>
        /// Пишет (обновляет) элемент (если он ещё не существует), либо возвращает индекс существующего элемента
        /// с указанными Left (продолжением слева), Value (значением) и Right (продолжением справа).
        /// </summary>
        /// <param name="left">Индекс левого (Left) элемента, который будет является продолжением создаваемого элемента влево.</param>
        /// <param name="value">Индекс элемента, который будет являться значением данного создаваемого элемента.</param>
        /// <param name="right">Индекс правого (Right) элемента, который будет являться продолжением создаваемого элемента вправо.</param>
        /// <returns>Индекс созданного или существующего элемента, с указанным Left (продолжением влево), Value (значением) и Right (продолжением вправо)</returns>
        /// <remarks>
        /// Традиционно последовательности (строки, массивы) и т.п. представлены в виде ссылок на их начало
        /// (может присутствовать информация о длине последовательности или есть соглашение о том, что символизирует окончание последовательности).
        /// Уникальность последовательностей не гарантируются, может существовать несколько одинаковых последовательностей.
        /// Чтобы узнать как взаимосвязаны эти последовательности необходимо выполнять дополнительные вычисления.
        /// Выделение памяти происходит по требованию, могут возникать проблемы с неравномерным выделением памяти.
        /// (В те места, где память высвободилась память нельзя разместить новые элементы без перемещение используемой памяти)
        /// Не хранятся обратные ссылки на указатели (что требует статического размещения информации в памяти, затрудняет её перемещение).
        /// TODO: Решить обновлять ли все элементы в последовательности (составном элементе), если обновляется один из них?
        /// </remarks>
        TElement Write(ref TElement address, TElement left, TElement value, TElement right);

        /// <summary>
        /// Возвращает значение, определяющее существует ли элемент с указанным индексом в базе данных (хранилище).
        /// </summary>
        /// <param name="element">Индекс проверяемого на существование элемента.</param>
        /// <returns>Значение, определяющее существует ли связь.</returns>
        bool Exists(TElement element);

        /// <summary>Удаляет элемент с указанным индексом.</summary>
        /// <param name="element">Индекс удаляемого элемента.</param>
        /// <remarks>
        /// Возможно имеет смысл все ссылки на другие элементы принимать по ref (ссылке)
        /// и если указанная ссылка не является корректной - обнулять её (чтобы хранение неверных ссылок не стало ошибкой в будущем).
        /// Тогда в функции exists не нужно будет возвращать тип bool.
        /// TODO: Решить удалять ли все элементы в последовательности (составном элементе), если удаляется один из них?
        /// </remarks>
        void Delete(ref TElement element);

        /// <summary>
        /// Выполняет чтение всех элементов, для которых указаны адреса.
        /// </summary>
        /// <param name="reader">Обработчик каждого подходящего элемента.</param>
        /// <param name="addresses">Массив адресов, где необходимо произвести чтение.</param>
        /// <returns>True, если проход по элементам не был прерван и False в обратном случае.</returns>
        bool ReadByAddress(ElementReader<TElement> reader, params TElement[] addresses);

        /// <summary>
        /// Выполняет чтение всех элементов, соответствующим шаблону значения.
        /// </summary>
        /// <param name="value">Значение, определяющее соответствующие шаблону элементы. (0 - любое значение, 1..∞ конкретное значение)</param>
        /// <param name="reader">Обработчик каждого подходящего элемента.</param>
        /// <returns>True, в случае если проход по элементам не был прерван и False в обратном случае.</returns>
        /// <remarks>
        /// TODO:
        /// Безопасно ли удаление в процессе прохода? - Если это будет двусвязный список, то да.
        /// В теории можно разработать способ безопасного удаления элементов дерева,
        /// но тогда балансировку нужно будет производить только при добавлении новых элементов.
        /// Опасно по сути не только удаление в процессе прохода, но и добавление и балансировка.
        /// Возможно балансировку можно выполнять отложено, например раз в некоторое время,
        /// по аналогии это будет ближе к своего рода сборке мусора, по факту,
        /// при определённых настройках это может стать оптимизацией производительности алгоритма дерева.
        /// </remarks>
        bool ReadByValue(TElement value, ElementReader<TElement> reader);
    }
}