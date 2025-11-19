html {
    font - size: 14px;
    height: 100 %;
}

@media(min - width: 768px) {
  html {
        font - size: 16px;
    }
}

body {
    font - family: "Poppins", sans - serif;
    color: #333;
    background - color: #f8f9fa;
    min - height: 100vh;
    display: flex;
    flex - direction: column;
    margin: 0;
    padding: 0;
}

/* Main content wrapper */
.content - wrapper {
    flex: 1 0 auto; /* This will make the content grow and push footer down */
    width: 100 %;
    padding - top: 76px; /* Space for fixed navbar */
}

/* Custom Colors */
:root {
    --primary - color: #2e7d32;
    --primary - dark: #1b5e20;
    --primary - light: #4caf50;
    --secondary - color: #ff9800;
    --secondary - dark: #f57c00;
    --accent - color: #03a9f4;
    --gradient - start: #2e7d32;
    --gradient - end: #4caf50;
}

/* Text Gradient */
.text - gradient {
    background: linear - gradient(90deg, var(--gradient - start), var(--gradient - end));
    -webkit - background - clip: text;
    background - clip: text;
    -webkit - text - fill - color: transparent;
    font - weight: 700;
}

/* Navbar Styling */
.navbar {
    padding: 1rem 0;
    transition: all 0.3s ease;
    background: rgba(255, 255, 255, 0.95)!important;
    backdrop - filter: blur(10px);
    box - shadow: 0 2px 15px rgba(0, 0, 0, 0.1);
}

.navbar - brand {
    font - weight: 700;
    font - size: 1.5rem;
}

.navbar - brand span {
    background: linear - gradient(90deg, var(--gradient - start), var(--gradient - end));
    -webkit - background - clip: text;
    background - clip: text;
    -webkit - text - fill - color: transparent;
}

.navbar.nav - link {
    font - weight: 500;
    margin: 0 0.5rem;
    position: relative;
    transition: all 0.3s ease;
}

.navbar.nav - link:after {
    content: "";
    position: absolute;
    width: 0;
    height: 2px;
    bottom: 0;
    left: 0;
    background: linear - gradient(90deg, var(--gradient - start), var(--gradient - end));
    transition: width 0.3s ease;
}

.navbar.nav - link: hover:after {
    width: 100 %;
}

.navbar - toggler {
    border: none;
    padding: 0.5rem;
}

.navbar - toggler:focus {
    box - shadow: none;
}

/* Hero Section */
.hero - section {
    position: relative;
    background: url("https://images.unsplash.com/photo-1500382017468-9049fed747ef?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1932&q=80")
    no - repeat center center;
    background - size: cover;
    min - height: 600px;
    display: flex;
    align - items: center;
    color: white;
    margin - top: -76px;
    padding - top: 76px;
    overflow: hidden;
}

.hero - overlay {
    position: absolute;
    top: 0;
    left: 0;
    width: 100 %;
    height: 100 %;
    background: linear - gradient(135deg, rgba(46, 125, 50, 0.9), rgba(76, 175, 80, 0.8));
}

.hero - content {
    position: relative;
    z - index: 2;
    padding: 4rem 0;
}

.hero - title {
    font - size: 3.5rem;
    font - weight: 800;
    margin - bottom: 1rem;
    text - shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
}

.hero - subtitle {
    font - size: 1.5rem;
    font - weight: 300;
    margin - bottom: 2rem;
    text - shadow: 0 2px 5px rgba(0, 0, 0, 0.2);
}

.hero - buttons.btn {
    padding: 0.75rem 2rem;
    font - weight: 600;
    border - radius: 50px;
    box - shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
    transition: all 0.3s ease;
}

.hero - buttons.btn:hover {
    transform: translateY(-3px);
    box - shadow: 0 6px 20px rgba(0, 0, 0, 0.25);
}

.wave - container {
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100 %;
}

/* Stats Section */
.stats - section {
    padding: 3rem 0;
    margin - top: -2rem;
    position: relative;
    z - index: 3;
}

.counter - card {
    background: white;
    border - radius: 15px;
    padding: 2rem;
    box - shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
    transition: all 0.3s ease;
}

.counter - card:hover {
    transform: translateY(-10px);
    box - shadow: 0 15px 35px rgba(0, 0, 0, 0.15);
}

.counter - icon {
    font - size: 2.5rem;
    margin - bottom: 1rem;
    color: var(--primary - color);
}

.counter {
    font - size: 2.5rem;
    font - weight: 700;
    margin - bottom: 0.5rem;
    background: linear - gradient(90deg, var(--gradient - start), var(--gradient - end));
    -webkit - background - clip: text;
    background - clip: text;
    -webkit - text - fill - color: transparent;
}

/* Features Section */
.features - section {
    padding: 5rem 0;
}

.section - title {
    font - size: 2.5rem;
    font - weight: 700;
    margin - bottom: 1rem;
}

.section - subtitle {
    font - size: 1.2rem;
    color: #666;
    max - width: 700px;
    margin: 0 auto;
}

.feature - card {
    background: white;
    border - radius: 15px;
    padding: 2rem;
    height: 100 %;
    box - shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
    transition: all 0.3s ease;
    border - top: 5px solid transparent;
    border - image: linear - gradient(90deg, var(--gradient - start), var(--gradient - end));
    border - image - slice: 1;
}

.feature - card:hover {
    transform: translateY(-10px);
    box - shadow: 0 15px 35px rgba(0, 0, 0, 0.15);
}

.feature - icon {
    font - size: 2.5rem;
    margin - bottom: 1.5rem;
    color: var(--primary - color);
    background: linear - gradient(135deg, var(--gradient - start), var(--gradient - end));
    -webkit - background - clip: text;
    background - clip: text;
    -webkit - text - fill - color: transparent;
}

.feature - card h3 {
    font - size: 1.5rem;
    font - weight: 600;
    margin - bottom: 1rem;
}

.feature - card p {
    color: #666;
    margin - bottom: 1.5rem;
}

.feature - card.btn {
    border - radius: 50px;
    padding: 0.5rem 1.5rem;
    font - weight: 500;
}

/* CTA Section */
.cta - section {
    background: linear - gradient(135deg, var(--gradient - start), var(--gradient - end));
    padding: 5rem 0;
    color: white;
    text - align: center;
    margin: 5rem 0;
    border - radius: 15px;
    box - shadow: 0 15px 35px rgba(0, 0, 0, 0.2);
}

.cta - title {
    font - size: 2.5rem;
    font - weight: 700;
    margin - bottom: 1rem;
}

.cta - subtitle {
    font - size: 1.2rem;
    margin - bottom: 2rem;
    opacity: 0.9;
}

.cta - section.btn {
    padding: 0.75rem 2rem;
    font - weight: 600;
    border - radius: 50px;
    box - shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
    transition: all 0.3s ease;
}

.cta - section.btn:hover {
    transform: translateY(-3px);
    box - shadow: 0 6px 20px rgba(0, 0, 0, 0.25);
}

/* Quick Actions Section */
.quick - actions - section {
    margin - bottom: 5rem;
}

.quick - actions - card {
    background: white;
    border - radius: 15px;
    padding: 2rem;
    box - shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
}

.quick - actions - card h3 {
    font - size: 1.5rem;
    font - weight: 600;
    margin - bottom: 1.5rem;
    color: var(--primary - color);
}

.quick - actions - card.btn {
    border - radius: 50px;
    padding: 0.75rem 1.5rem;
    font - weight: 500;
    margin - right: 1rem;
    margin - bottom: 1rem;
    transition: all 0.3s ease;
}

.quick - actions - card.btn:hover {
    transform: translateY(-3px);
    box - shadow: 0 6px 15px rgba(0, 0, 0, 0.1);
}

/* Testimonials Section */
.testimonials - section {
    padding: 5rem 0;
}

.testimonial - card {
    background: white;
    border - radius: 15px;
    padding: 2rem;
    height: 100 %;
    box - shadow: 0 10px 30px rgba(0, 0, 0, 0.1);
    transition: all 0.3s ease;
}

.testimonial - card:hover {
    transform: translateY(-10px);
    box - shadow: 0 15px 35px rgba(0, 0, 0, 0.15);
}

.testimonial - content {
    font - style: italic;
    color: #555;
    margin - bottom: 1.5rem;
    position: relative;
}

.testimonial - content:before {
    content: '"';
    font - size: 4rem;
    position: absolute;
    top: -20px;
    left: -15px;
    color: rgba(76, 175, 80, 0.2);
    font - family: serif;
}

.testimonial - user {
    display: flex;
    align - items: center;
}

.testimonial - avatar {
    font - size: 2.5rem;
    margin - right: 1rem;
    color: var(--primary - color);
}

.testimonial - info h5 {
    font - weight: 600;
    margin - bottom: 0.25rem;
}

.testimonial - info p {
    color: #666;
    font - size: 0.9rem;
}

/* Footer */
.footer {
    background - color: #333;
    color: white;
    padding: 3rem 0 0;
    flex - shrink: 0; /* Prevent footer from shrinking */
    width: 100 %;
}

/* Buttons */
.btn - primary {
    background: linear - gradient(90deg, var(--gradient - start), var(--gradient - end));
    border: none;
    box - shadow: 0 4px 15px rgba(76, 175, 80, 0.3);
}

.btn - primary:hover {
    background: linear - gradient(90deg, var(--primary - dark), var(--primary - color));
    box - shadow: 0 6px 20px rgba(76, 175, 80, 0.4);
}

.btn - outline - primary {
    color: var(--primary - color);
    border - color: var(--primary - color);
}

.btn - outline - primary:hover {
    background - color: var(--primary - color);
    border - color: var(--primary - color);
}

/* Animation */
.pulse - btn {
    animation: pulse 2s infinite;
}

@keyframes pulse {
    0 % {
        box- shadow: 0 0 0 0 rgba(76, 175, 80, 0.7);
}
70 % {
    box- shadow: 0 0 0 10px rgba(76, 175, 80, 0);
  }
100 % {
    box- shadow: 0 0 0 0 rgba(76, 175, 80, 0);
  }
}

/* Page Header */
.page - header {
    background: linear - gradient(135deg, var(--gradient - start), var(--gradient - end));
    padding: 5rem 0 2rem; /* Increased top padding */
    margin - bottom: 2rem;
    color: white;
    border - radius: 0 0 1rem 1rem;
}

.page - title {
    font - size: 2.5rem;
    font - weight: 700;
    margin - bottom: 0.5rem;
}

.page - subtitle {
    font - size: 1.2rem;
    opacity: 0.9;
}

/* Form Styling */
.form - floating > .form - control,
.form - floating > .form - select {
    height: calc(3.5rem + 2px);
    padding: 1rem 0.75rem;
}

.form - floating > label {
    padding: 1rem 0.75rem;
}

.form - control: focus,
.form - select:focus {
    border - color: var(--primary - light);
    box - shadow: 0 0 0 0.25rem rgba(76, 175, 80, 0.25);
}

/* Card Styling */
.card {
    border: none;
    border - radius: 1rem;
    overflow: hidden;
}

.card - header {
    padding: 1rem 1.5rem;
    font - weight: 600;
}

.bg - gradient - primary {
    background: linear - gradient(90deg, var(--gradient - start), var(--gradient - end));
}

/* Main content area */
main {
    padding - bottom: 2rem;
}

/* Responsive Adjustments */
@media(max - width: 992px) {
  .hero - title {
        font - size: 2.5rem;
    }

  .hero - subtitle {
        font - size: 1.2rem;
    }

  .section - title {
        font - size: 2rem;
    }

  .page - title {
        font - size: 2rem;
    }
}

@media(max - width: 768px) {
  .hero - section {
        min - height: 500px;
    }

  .hero - title {
        font - size: 2rem;
    }

  .counter - card,
  .feature - card,
  .testimonial - card {
        margin - bottom: 1.5rem;
    }

  .page - title {
        font - size: 1.75rem;
    }
}
