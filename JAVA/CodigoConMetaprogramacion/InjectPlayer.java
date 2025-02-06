import java.lang.annotation.Retention;
import java.lang.annotation.RetentionPolicy;

@Retention(RetentionPolicy.RUNTIME) // La anotación estará disponible en tiempo de ejecución
public @interface InjectPlayer {
    
}