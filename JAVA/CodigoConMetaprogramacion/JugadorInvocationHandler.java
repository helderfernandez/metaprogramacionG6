import java.lang.reflect.InvocationHandler;
import java.lang.reflect.Method;

public class JugadorInvocationHandler implements InvocationHandler {
    private final Jugador target; // Objeto real que será interceptado

    public JugadorInvocationHandler(Jugador target) {
        this.target = target;
    }

    @Override
    public Object invoke(Object proxy, Method method, Object[] args) throws Throwable {
        // Interceptar la llamada al método
        System.out.println("Validando mensaje antes de ejecutar...");
        
        // Ejecutar el método real
        Object result = method.invoke(target, args);
        System.out.println("nombre del mensaje: " + method.getName());
        // Interceptar después de la ejecución
        System.out.println("mensaje ejecutado con éxito.");
        return result;
    }
}