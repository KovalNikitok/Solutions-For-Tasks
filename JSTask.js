	function timesFormated(time,formatingTime,format){//функция для перевода времени к формату; месяцы, дни, часы, минуты, секунды
		while(time>=format){
			time=time-format;
			formatingTime++;
		}
		return formatingTime;
	}
	function scrollWindow(){//функция скроллинга
		for(var i=0;i<10;i++){
			window.scrollBy(0,1920);
		}
	}
	function timeCorrection(time, format){//функция коррекции времени
		return time%format;
	}

	function finalResponse(quantity, time){//объект для console.table
		this.quantity=quantity;
		this.time=time;
	}

	function getTime(catalog){//функция получения времени
		var audioRow=[],  tracksLength=[]; //Создаём массивы для хранения данных из audioCatalog
		var	seconds=0,	minutes=0,	hours=0,  days=0,  months=0; //Переменные для хранения времени продолжительности треков
		for(var i=0; i<catalog.length;i++){
		//Получаем массив с длительностью треков типа [часы, минуты, секунды] (часы появляются только в случае, если продолжительность трека больше 60 минут)
			audioRow[i]=catalog[i].innerText.split('\n');
			tracksLength[i]=audioRow[i][audioRow[i].length-1].split(':');
		} 
		for(var i=0;i<tracksLength.length;i++){
			seconds+=+tracksLength[i][tracksLength[i].length-1];
			minutes+=+tracksLength[i][tracksLength[i].length-2];
			if(tracksLength[i].length===3){
				hours+=+tracksLength[i][tracksLength[i].length-3];
			}
		}//Получаем сумму продолжительности по времени всех треков в секундах, минутах и часах(если есть)
		
		minutes=timesFormated(seconds,minutes,60);
		seconds=timeCorrection(seconds,60);
		hours=timesFormated(minutes,hours,60);
		minutes=timeCorrection(minutes,60);
		days=timesFormated(hours,days,24);
		hours=timeCorrection(hours,24);
		months=timesFormated(days,months,30);
		days=timeCorrection(days,30);
		//форматирование и корректировка времени функциями
		
		return console.table([new finalResponse(tracksLength.length,((months>0)?(months+':'+days+':'+hours+':'+minutes+':'+seconds):
		(days>0)?(days+':'+hours+':'+minutes+':'+seconds):(hours>0)?(hours+':'+minutes+':'+seconds):
		(minutes+':'+seconds)))]); //возвращаем console.table с количеством треков и суммарной их продолжительностью
	}
		scrollWindow();//вызов функции скроллинга
		var audioCatalog = document.getElementsByClassName('audio_row audio_row_with_cover _audio_row');//Принимаем все элементы по классу
		getTime(audioCatalog);//вызов функции получения количества треков и их суммарной продолжительности