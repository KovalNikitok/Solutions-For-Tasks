	function timesFormated(time,formatingTime,format){//функция для перевода времени к формату; месяцы, дни, часы, минуты, секунды
		while(time>=format){
			time=time-format;
			formatingTime++;
		}
		return formatingTime;
	}
	function timeCorrection(time, format){//функция коррекции времени
		return time%format;
	}
	function getTimesString(hours,minutes,seconds){
		var days=0,months=0;
		//функция для перевода времени к формату; месяцы, дни, часы, минуты, секунды
		minutes=timesFormated(seconds,minutes,60);
		seconds=timeCorrection(seconds,60);
		hours=timesFormated(minutes,hours,60);
		minutes=timeCorrection(minutes,60);
		days=timesFormated(hours,days,24);
		hours=timeCorrection(hours,24);
		months=timesFormated(days,months,30);
		days=timeCorrection(days,30);
		
		return ((months>0)?(months+':'+days+':'+hours+':'+minutes+':'+seconds)://формируем строку(в зависимотси от имеющихся данных) вида: месяцы:дни:часы:минуты:секунды
		(days>0)?(days+':'+hours+':'+minutes+':'+seconds):(hours>0)?(hours+':'+minutes+':'+seconds):
		(minutes+':'+seconds));
	}
	async function scrollWindow(trackLengthLast){
		//функция скроллинга с получением конечного результата
		var scrolling=new Promise((resolve, reject) => {
			setTimeout(() => { 
				window.scrollBy(0,9000);//прокручиваем экран
				var audioCatalog = document.getElementsByClassName('audio_row audio_row_with_cover _audio_row');//получаем текущие треки
				if(trackLengthLast!=audioCatalog.length){
					//автоматически прокручиваем экран, вызывая рекурсию, пока не прогрузятся все треки
					scrollWindow(audioCatalog.length);
				}
				resolve(audioCatalog);
			}, 400)//задержка, необходимая при моей конфигурации для подгрузки новых запис
		});
		getTime(await scrolling);//вызов функции получения времени
	}

	function finalResponse(quantity, time){//функция-конструктор для console.table
		this.quantity=quantity;
		this.time=time;
	}

	function getTime(catalog){//функция получения времени
		var audioRow=[],  tracksLength=[]; //Создаём массивы для хранения данных из catalog
		var	seconds=0,	minutes=0,	hours=0; //Переменные для хранения времени продолжительности треков
		for(var i=0; i<catalog.length;i++){
		//Получаем массив с длительностью треков типа [часы, минуты, секунды] (часы появляются только в случае, если продолжительность трека больше 60 минут)
			audioRow[i]=catalog[i].innerText.split('\n');
			tracksLength[i]=audioRow[i][audioRow[i].length-1].split(':');
		} 
		for(var i=0;i<tracksLength.length;i++){
			//Получаем сумму продолжительности по времени всех треков в секундах, минутах и часах(если есть)
			seconds+=+tracksLength[i][tracksLength[i].length-1];
			minutes+=+tracksLength[i][tracksLength[i].length-2];
			if(tracksLength[i].length===3){
				hours+=+tracksLength[i][tracksLength[i].length-3];
			}
		}
		var timesString=getTimesString(hours,minutes,seconds);//вызываем функцию преобразования часов, минут и секунд в строку формата (месяцы:дни:часы:минуты:секунды)
		return console.table([new finalResponse(tracksLength.length,timesString)]);
		//возвращаем console.table с количеством треков и суммарной их продолжительностью
	}	
		//Принимаем все элементы по классу
		var audioCatalog = document.getElementsByClassName('audio_row audio_row_with_cover _audio_row');
		window.scrollBy(0,9000); //первая прокрутка экрана для попытки загрузить новые треки, если таковые имеются
		scrollWindow(audioCatalog.length);//вызов функции скроллинга и получения результата
