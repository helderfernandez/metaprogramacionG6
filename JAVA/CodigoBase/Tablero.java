public class Tablero {
	protected char casillas[];
	protected int jugadas;

	public Tablero( ) {
		casillas = new char[9];
		for (int i = 0; i < casillas.length; i++) {
			casillas[i] = '_';
		}
		jugadas = 0;
	}

	public void dibujarTablero() {
		System.out.println(casillas[0] + " |" + casillas[1] + " |" + casillas[2]);
		System.out.println("________");
		System.out.println(casillas[3] + " |" + casillas[4] + " |" + casillas[5]);
		System.out.println("________");
		System.out.println(casillas[6] + " |" + casillas[7] + " |" + casillas[8]);
		mostrarJugadasDisponibles();
	} 

	private void  mostrarJugadasDisponibles(){
		System.out.println("Jugadas disponibles: " + (9-jugadas));
	}

	public boolean marcarJugada(int posicion, Jugador x) {
		if (posicion > 8 || posicion < 0)
			return false;
		boolean exito = false;
		if (casillas[posicion] == '_') {
			casillas[posicion] = x.ficha;
			exito = true;
			jugadas++;
		}
		return exito;
	}

	public boolean esGanador(Jugador x) {
		boolean gano = false;
		char f = x.ficha;
		if (estaMarcado(0, f) && estaMarcado(4, f) && estaMarcado(8, f))
			gano = true;
		if (estaMarcado(2, f) && estaMarcado(4, f) && estaMarcado(6, f))
			gano = true;
		for (int i = 0; i <= 2; i++) {
			if (estaMarcado(i, f) && estaMarcado(i + 3, f) && estaMarcado(i + 6, f))
				gano = true;
		}
		for (int i = 0; i <= 6; i = i + 3) {
			if (estaMarcado(i, f) && estaMarcado(i + 1, f) && estaMarcado(i + 2, f))
				gano = true;
		}
		return gano;
	}

	private boolean estaMarcado(int i, char f) {
		return casillas[i] == f;
	}

	public boolean hayJugadas() {
		return jugadas < 9;
	}
}
